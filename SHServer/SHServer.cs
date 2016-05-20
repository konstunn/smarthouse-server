using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO.Ports;
using System.IO;
using System.Timers;


namespace SmartHouseServer
{
    public class SHServer
    {
        /// <summary>
        /// Количество данных, при которых производится сохранение
        /// </summary>
        public int ValuesSaveCount { get; set; }

        public enum SHCommand
        {
            GET_TEMPERATURE = 0x01,
            GET_HUMIDITY = 0x02,
            GET_ILLUMINATION = 0x03
        }

        public Dictionary<string, Measurement> measurements = new Dictionary<string, Measurement>();

        public delegate void DataReceived(byte[] data);
        public event DataReceived OnDataReceived;

        protected SerialPort MKPort;
        public SerialPort Port
        {
            get { return MKPort; }
        }

        protected SHServerLogger logger = new SHServerLogger();
        public SHServerLogger Logger
        {
            get { return logger; }
        }

        protected SHServerTCPServer tcpListener;

        public SHServer()
        {
            ValuesSaveCount = 10000;
            measurements.Add("temperature", new Measurement((byte)SHCommand.GET_TEMPERATURE, this, "Температура", "°С", "temperature"));
            measurements.Add("humidity", new Measurement((byte)SHCommand.GET_HUMIDITY, this, "Влажность", "%", "humidity"));
            measurements.Add("illumination", new Measurement((byte)SHCommand.GET_ILLUMINATION, this, "Освещенность", "", "illumination"));
        }


        /// <summary>
        /// Открываем соединение с микроконтроллером
        /// </summary>
        /// <param name="port"></param>
        public bool ConnectToMK(SerialPort port)
        {
            MKPort = port;
            try
            {                
                port.Open();
                MKPort.DataReceived += MKPort_DataReceived;
                MKPort.ErrorReceived += MKPort_ErrorReceived;
                Console.WriteLine("Порт открыт");
                return true;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка при открытии порта:");
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            return false;
        }
        /// <summary>
        /// Событие при получении ошибки порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MKPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("Ошибка?");
        }
        /// <summary>
        /// Событие при получении данных с порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MKPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (MKPort.BytesToRead < 3)
                return;
            byte[] buffer = new byte[MKPort.BytesToRead];
            MKPort.Read(buffer, 0, MKPort.BytesToRead);
            
            BinaryReader br = new BinaryReader(new MemoryStream(buffer));
            

            OnDataReceived(buffer);

            foreach (Measurement mea in measurements.Values)
            {
                mea.DataRead(br);
            }
        }
        /// <summary>
        /// Отправляем команду микроконтроллеру
        /// </summary>
        /// <param name="command"></param>
        public void SendCommandToMK(byte command)
        {
            if (MKPort==null || !MKPort.IsOpen)
            {
                Console.WriteLine("Не получится передать команду: порт не открыт");
            }
            try
            {
                MKPort.Write(new byte[] { command }, 0, 1);                
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка при отправке команды:");
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void StartTcpServer(int port)
        {
            tcpListener = new SHServerTCPServer();
            tcpListener.StartListener(port, this);
        }

        public void StopTcpServer()
        {
            if (tcpListener != null)
            {
                tcpListener.StopListener();
            }
        }

        public void SaveMeasurementLogs()
        {
            measurements["humidity"].WriteLogData();
            measurements["temperature"].WriteLogData();
            measurements["illumination"].WriteLogData();
        }
       

        ~SHServer()
        {

            foreach (Measurement m in measurements.Values)
            {
                m.StopMeasurementTimer();
            }
            if (MKPort != null && MKPort.IsOpen)
                MKPort.Close();
        }

    }
}
