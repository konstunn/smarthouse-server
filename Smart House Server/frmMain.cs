using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using SmartHouseServer;

namespace Smart_House_Server
{
    public partial class frmMain : Form
    {
        SHServer server = new SHServer();
        bool tcpServerStarted = false;
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshAvailablePorts();

            foreach (string s in server.measurements.Keys)
            {
                cmbMeasurementSelection.Items.Add(s);
                clbGraphMeasurements.Items.Add(s);
            }
            server.measurements["temperature"].AddPoint = AddChartPoint;
            server.measurements["temperature"].RemovePoint = RemoveChartPoint;
            server.measurements["humidity"].AddPoint = AddChartPoint;
            server.measurements["humidity"].RemovePoint = RemoveChartPoint;
            server.measurements["illumination"].AddPoint = AddChartPoint;
            server.measurements["illumination"].RemovePoint = RemoveChartPoint;
            
            server.OnDataReceived += server_OnDataReceived;

            RefreshMyIp();

            DateTime[] avdates = server.Logger.GetAvailableDates();
            if (avdates != null)
            {
                for (int i = 0; i < avdates.Length; i++)
                {
                    cmbLogDates.Items.Add(avdates[i].ToShortDateString());
                }
            }
        }

        public void AddChartPoint(MeasurementData data, string key)
        {
            if (this.InvokeRequired)
            {
                if (data == null)
                    return;
                Measurement.AddChartPoint acp = AddChartPoint;
                this.Invoke(acp, data, key);
            }
            else
            {
                chart1.Series[key].Points.AddXY(data.CreationTime.ToOADate(), data.Value);
            }
        }
        public void RemoveChartPoint(int i, string key)
        {
            if (this.InvokeRequired)
            {
                
                Measurement.RemoveChartPointAt rp = RemoveChartPoint;
                this.Invoke(rp, i, key);
            }
            else
            {
                chart1.Series[key].Points.RemoveAt(i);
            }
        }
        

        List<byte[]> dataHistory = new List<byte[]>();
        void server_OnDataReceived(byte[] data)
        {

            dataHistory.Add(data);
            if (dataHistory.Count > (int)nudRespHistoryLength.Value)
            {
                dataHistory.RemoveAt(0);
            }
            RefreshDataViewControls();
            
        }

        delegate void voidF();
        void RefreshDataViewControls()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    voidF vf = RefreshDataViewControls;
                    this.Invoke(vf);
                }
                else
                {
                    int vc = (int)nudCOMRespViewCount.Value;
                    if (vc > dataHistory.Count)
                        vc = dataHistory.Count;
                    string d = "";
                    if (chkCOMRespViewDivide.Checked)
                    {
                        d = "\n";
                    }
                    txtCOMRespHex.Text = "";
                    txtCOMRespText.Text = "";
                    for (int i = 0; i < vc; i++)
                    {
                        txtCOMRespHex.AppendText(ConvertBytesToBString(dataHistory[dataHistory.Count - 1 - i]));
                        txtCOMRespHex.AppendText(d);
                        txtCOMRespText.AppendText(Encoding.ASCII.GetString(dataHistory[dataHistory.Count - 1 - i]));
                        txtCOMRespText.AppendText(d);
                    }
                }
            }
            catch (Exception ex)
            { 
                //УУпсс

            }
        }



        public void RefreshAvailablePorts()
        {
            tsdbSelectCom.DropDownItems.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string str in ports)
            {
                tsdbSelectCom.DropDownItems.Add(str);                
            }
            if (tsdbSelectCom.DropDownItems.Count < 1)
            {
                tsdbSelectCom.DropDownItems.Add("<нет доступных портов>");
            }
            tsdbSelectCom.DropDownItems.Add("<обновить>");
        }

        private void tsdbSelectCom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "<обновить>")
            {
                RefreshAvailablePorts();
            }
            else if (e.ClickedItem.Text == "<отключить>")
            {
                if (server.Port.IsOpen)
                {
                    server.Port.Close();
                    RefreshAvailablePorts();
                }
                lblCOMConnectionStatus.Text = "не подключен";
            }
            else if (e.ClickedItem.Text.StartsWith("COM"))
            {
                if (server.Port != null && server.Port.IsOpen)
                {
                    server.Port.Close();
                }
                SerialPort com = new SerialPort(e.ClickedItem.Text, 9600, Parity.None, 8, StopBits.One);
                if (server.ConnectToMK(com))
                {
                    lblCOMConnectionStatus.Text = "подключен";
                    tsdbSelectCom.Text = e.ClickedItem.Text;
                    tsdbSelectCom.DropDownItems.Add("<отключить>");
                }
                else
                {
                    lblCOMConnectionStatus.Text = "не подключен";
                    tsdbSelectCom.Text = "COM";
                    RefreshAvailablePorts();
                }
            }
        }

        #region Показания

        string selectedMeasurement;
        private void cmbMeasurementSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                server.measurements[selectedMeasurement].OnDataReceived -= RefreshLastMeasurementValue;
            }
            catch(Exception ex){
                
            }
            selectedMeasurement = cmbMeasurementSelection.Text;
            chkMeasurementEnableTimer.Checked = server.measurements[selectedMeasurement].AutoMeasurement;
            nudMeasurementInterval.Value = server.measurements[selectedMeasurement].AutoMeasurementInterval;
            if (server.measurements[selectedMeasurement].Last != null)
            {
                lblMeasurementLastValue.Text = server.measurements[selectedMeasurement].Last.ToString();
            }
            else
            {
                lblMeasurementLastValue.Text = "No data";
            }
            server.measurements[selectedMeasurement].OnDataReceived += RefreshLastMeasurementValue;
        }
        private void RefreshLastMeasurementValue(MeasurementData data)
        {
            if (this.InvokeRequired)
            {
                Measurement.DataReceived dr = RefreshLastMeasurementValue;
                this.Invoke(dr, new object[] { data });
            }
            else
            {
                chart1.Invalidate();
                lblMeasurementLastValue.Text = data.ToString();
            }
        }

        private void chkMeasurementEnableTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedMeasurement != null && selectedMeasurement.Trim() != "")
            {
                server.measurements[selectedMeasurement].AutoMeasurement = chkMeasurementEnableTimer.Checked;
            }
        }

        private void nudMeasurementInterval_ValueChanged(object sender, EventArgs e)
        {
            if (selectedMeasurement != null && selectedMeasurement.Trim() != "")
            {
                server.measurements[selectedMeasurement].AutoMeasurementInterval = (int)nudMeasurementInterval.Value;
            }
        }

        private void btnMeasurementRefresh_Click(object sender, EventArgs e)
        {
            if (selectedMeasurement == null)
                return;
            server.measurements[selectedMeasurement].Refresh();
            if (server.measurements[selectedMeasurement].Last != null)
            {                
                lblMeasurementLastValue.Text = server.measurements[selectedMeasurement].Last.ToString();
            }
            else
            {
                lblMeasurementLastValue.Text = "No data";
            }

        }

        #endregion

        private void txtCOMSendText_TextChanged(object sender, EventArgs e)
        {
            if (txtCOMSendText.Focused)
                txtCOMSendBinary.Text = ConvertASCIIToBString(txtCOMSendText.Text);
        }



        private string ConvertBytesToBString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2} ", b);
            }
            return sb.ToString().Trim();
        }
        private byte[] ConvertBStringToBytes(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Replace(" ", "");
            str = sb.ToString();
            string tmp;
            byte[] b = new byte[str.Length/2];            
            for (int i = 0; i < str.Length; i += 2)
            {
                tmp = str.Substring(i, 2);
                b[i/2] = Convert.ToByte(tmp, 16);
                
            }
            return b;


        }
        private string ConvertBStringToASCII(string str)
        {
            if (str.Trim() == "")
                return "";
            StringBuilder sb = new StringBuilder(str);
            StringBuilder sbout = new StringBuilder();
            sb.Replace(" ", "");
            str = sb.ToString();
            if (str.Length % 2 != 0)
                str += 0;
            string tmp;
            
            byte[] b = new byte[1];
            for (int i = 0; i < str.Length; i += 2)
            {
                tmp = str.Substring(i, 2);
                b[0] = Convert.ToByte(tmp, 16);
                sbout.Append(Encoding.ASCII.GetString(b));

            }
            return sbout.ToString();

        }
        private string ConvertASCIIToBString(string str)
        {
            return ConvertBytesToBString(Encoding.ASCII.GetBytes(txtCOMSendText.Text));
        }

        private void txtCOMSendBinary_TextChanged(object sender, EventArgs e)
        {
            if (txtCOMSendBinary.Focused)
                txtCOMSendText.Text = ConvertBStringToASCII(txtCOMSendBinary.Text);
        }

        private void txtCOMSendBinary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.Text = ((int)e.KeyChar).ToString();
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar >= 'a' && e.KeyChar <= 'f' || e.KeyChar == ' ' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCOMSend_Click(object sender, EventArgs e)
        {
            if (server.Port != null && server.Port.IsOpen)
            {
                if (txtCOMSendBinary.Text != "")
                {
                    byte[] bytes = ConvertBStringToBytes(txtCOMSendBinary.Text);
                    server.Port.Write(bytes, 0, bytes.Length);
                }
            }
        }

        private void tsdbSelectCom_Click(object sender, EventArgs e)
        {

        }

        private void clbGraphMeasurements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            server.SaveMeasurementLogs();
            server.StopTcpServer();
            if (server.Port != null)
            {
                server.Port.Close();
            }
            server = null;
            
        }

        private void lblMyIp_DoubleClick(object sender, EventArgs e)
        {
            RefreshMyIp();
        }

        public void RefreshMyIp()
        {
            try
            {
                lblMyIp.Text = SHServerTCPServer.GetMyIp();
            }
            catch{}
        }

        private void btnStartTcpServer_Click(object sender, EventArgs e)
        {
            if (!tcpServerStarted)
            {
                server.StartTcpServer((int)nudPort.Value);
                tcpServerStarted = true;
                btnStartTcpServer.Text = "Остановить TCP сервер";
                lblServerStatus.Text = "tcp-server: запущен[порт " + (int)nudPort.Value + "]";
            }
            else
            {
                server.StopTcpServer();
                tcpServerStarted = false;
                btnStartTcpServer.Text = "Запустить TCP сервер";
                lblServerStatus.Text = "tcp-server: не запущен";
            }
        }

        private void cmbLogDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = cmbLogDates.Text;
            cmbLogMeasurements.Items.Clear();
            if (Directory.Exists("data\\" + date))
            {
                DirectoryInfo di = new DirectoryInfo("data\\" + date);
                FileInfo[] files = di.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    cmbLogMeasurements.Items.Add(files[i].Name.Substring(0, files[i].Name.Length - files[i].Extension.Length));
                }
            }
        }

        private void cmbLogMeasurements_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = cmbLogDates.Text;
            List<MeasurementData> history = server.Logger.GetMeasurements(cmbLogMeasurements.Text, date);
            if (history == null)
            {
                return;
            }
            chart2.Series["History"].Points.Clear();
            foreach (MeasurementData data in history)
            {
                chart2.Series["History"].Points.AddXY(data.CreationTime, data.Value);
            }
        }
    }
}
