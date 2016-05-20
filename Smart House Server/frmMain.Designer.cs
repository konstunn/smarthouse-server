namespace Smart_House_Server
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsdbSelectCom = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblCOMConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMyIp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkCOMRespViewDivide = new System.Windows.Forms.CheckBox();
            this.nudCOMRespViewCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCOMRespText = new System.Windows.Forms.TextBox();
            this.txtCOMRespHex = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstRespHistory = new System.Windows.Forms.ListBox();
            this.nudRespHistoryLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCOMSend = new System.Windows.Forms.Button();
            this.txtCOMSendBinary = new System.Windows.Forms.TextBox();
            this.txtCOMSendText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clbGraphMeasurements = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMeasurementLastValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMeasurementRefresh = new System.Windows.Forms.Button();
            this.nudMeasurementInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMeasurementEnableTimer = new System.Windows.Forms.CheckBox();
            this.cmbMeasurementSelection = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lstTcpConnections = new System.Windows.Forms.ListBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartTcpServer = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmbLogMeasurements = new System.Windows.Forms.ComboBox();
            this.cmbLogDates = new System.Windows.Forms.ComboBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCOMRespViewCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespHistoryLength)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasurementInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbSelectCom,
            this.lblCOMConnectionStatus,
            this.lblServerStatus,
            this.lblMyIp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsdbSelectCom
            // 
            this.tsdbSelectCom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdbSelectCom.Image = ((System.Drawing.Image)(resources.GetObject("tsdbSelectCom.Image")));
            this.tsdbSelectCom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdbSelectCom.Name = "tsdbSelectCom";
            this.tsdbSelectCom.Size = new System.Drawing.Size(48, 22);
            this.tsdbSelectCom.Text = "COM";
            this.tsdbSelectCom.ToolTipText = "Доступные ком-порты";
            this.tsdbSelectCom.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbSelectCom_DropDownItemClicked);
            this.tsdbSelectCom.Click += new System.EventHandler(this.tsdbSelectCom_Click);
            // 
            // lblCOMConnectionStatus
            // 
            this.lblCOMConnectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblCOMConnectionStatus.Name = "lblCOMConnectionStatus";
            this.lblCOMConnectionStatus.Size = new System.Drawing.Size(90, 19);
            this.lblCOMConnectionStatus.Text = "не подключен";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(130, 19);
            this.lblServerStatus.Text = "tcp-server: не запущен";
            // 
            // lblMyIp
            // 
            this.lblMyIp.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMyIp.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.lblMyIp.Name = "lblMyIp";
            this.lblMyIp.Size = new System.Drawing.Size(29, 19);
            this.lblMyIp.Text = "[ip]";
            this.lblMyIp.ToolTipText = "Двойной клик, чтобы обновить";
            this.lblMyIp.DoubleClick += new System.EventHandler(this.lblMyIp_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 370);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkCOMRespViewDivide);
            this.tabPage1.Controls.Add(this.nudCOMRespViewCount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCOMSend);
            this.tabPage1.Controls.Add(this.txtCOMSendBinary);
            this.tabPage1.Controls.Add(this.txtCOMSendText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Порт";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkCOMRespViewDivide
            // 
            this.chkCOMRespViewDivide.AutoSize = true;
            this.chkCOMRespViewDivide.Location = new System.Drawing.Point(306, 75);
            this.chkCOMRespViewDivide.Name = "chkCOMRespViewDivide";
            this.chkCOMRespViewDivide.Size = new System.Drawing.Size(176, 17);
            this.chkCOMRespViewDivide.TabIndex = 7;
            this.chkCOMRespViewDivide.Text = "разделять переносом строки";
            this.chkCOMRespViewDivide.UseVisualStyleBackColor = true;
            // 
            // nudCOMRespViewCount
            // 
            this.nudCOMRespViewCount.Location = new System.Drawing.Point(229, 72);
            this.nudCOMRespViewCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCOMRespViewCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCOMRespViewCount.Name = "nudCOMRespViewCount";
            this.nudCOMRespViewCount.Size = new System.Drawing.Size(71, 20);
            this.nudCOMRespViewCount.TabIndex = 6;
            this.nudCOMRespViewCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выводить";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(166, 98);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtCOMRespText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCOMRespHex);
            this.splitContainer1.Size = new System.Drawing.Size(421, 240);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 4;
            // 
            // txtCOMRespText
            // 
            this.txtCOMRespText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCOMRespText.Location = new System.Drawing.Point(0, 0);
            this.txtCOMRespText.Multiline = true;
            this.txtCOMRespText.Name = "txtCOMRespText";
            this.txtCOMRespText.Size = new System.Drawing.Size(209, 240);
            this.txtCOMRespText.TabIndex = 0;
            // 
            // txtCOMRespHex
            // 
            this.txtCOMRespHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCOMRespHex.Location = new System.Drawing.Point(0, 0);
            this.txtCOMRespHex.Multiline = true;
            this.txtCOMRespHex.Name = "txtCOMRespHex";
            this.txtCOMRespHex.Size = new System.Drawing.Size(208, 240);
            this.txtCOMRespHex.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lstRespHistory);
            this.groupBox1.Controls.Add(this.nudRespHistoryLength);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 280);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ответы";
            // 
            // lstRespHistory
            // 
            this.lstRespHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRespHistory.FormattingEnabled = true;
            this.lstRespHistory.Location = new System.Drawing.Point(6, 40);
            this.lstRespHistory.Name = "lstRespHistory";
            this.lstRespHistory.Size = new System.Drawing.Size(140, 238);
            this.lstRespHistory.TabIndex = 2;
            // 
            // nudRespHistoryLength
            // 
            this.nudRespHistoryLength.Location = new System.Drawing.Point(64, 14);
            this.nudRespHistoryLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRespHistoryLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRespHistoryLength.Name = "nudRespHistoryLength";
            this.nudRespHistoryLength.Size = new System.Drawing.Size(84, 20);
            this.nudRespHistoryLength.TabIndex = 1;
            this.nudRespHistoryLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Хранить:";
            // 
            // btnCOMSend
            // 
            this.btnCOMSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCOMSend.Location = new System.Drawing.Point(593, 6);
            this.btnCOMSend.Name = "btnCOMSend";
            this.btnCOMSend.Size = new System.Drawing.Size(121, 46);
            this.btnCOMSend.TabIndex = 2;
            this.btnCOMSend.Text = "Отправить";
            this.btnCOMSend.UseVisualStyleBackColor = true;
            this.btnCOMSend.Click += new System.EventHandler(this.btnCOMSend_Click);
            // 
            // txtCOMSendBinary
            // 
            this.txtCOMSendBinary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCOMSendBinary.Location = new System.Drawing.Point(6, 32);
            this.txtCOMSendBinary.Name = "txtCOMSendBinary";
            this.txtCOMSendBinary.Size = new System.Drawing.Size(581, 20);
            this.txtCOMSendBinary.TabIndex = 1;
            this.txtCOMSendBinary.TextChanged += new System.EventHandler(this.txtCOMSendBinary_TextChanged);
            this.txtCOMSendBinary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCOMSendBinary_KeyPress);
            // 
            // txtCOMSendText
            // 
            this.txtCOMSendText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCOMSendText.Location = new System.Drawing.Point(6, 6);
            this.txtCOMSendText.Name = "txtCOMSendText";
            this.txtCOMSendText.Size = new System.Drawing.Size(581, 20);
            this.txtCOMSendText.TabIndex = 0;
            this.txtCOMSendText.TextChanged += new System.EventHandler(this.txtCOMSendText_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(722, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Показания";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clbGraphMeasurements);
            this.groupBox3.Location = new System.Drawing.Point(8, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 164);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "График";
            this.groupBox3.Visible = false;
            // 
            // clbGraphMeasurements
            // 
            this.clbGraphMeasurements.FormattingEnabled = true;
            this.clbGraphMeasurements.Location = new System.Drawing.Point(6, 19);
            this.clbGraphMeasurements.Name = "clbGraphMeasurements";
            this.clbGraphMeasurements.Size = new System.Drawing.Size(179, 139);
            this.clbGraphMeasurements.TabIndex = 0;
            this.clbGraphMeasurements.SelectedIndexChanged += new System.EventHandler(this.clbGraphMeasurements_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMeasurementLastValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnMeasurementRefresh);
            this.groupBox2.Controls.Add(this.nudMeasurementInterval);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkMeasurementEnableTimer);
            this.groupBox2.Controls.Add(this.cmbMeasurementSelection);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 162);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройка";
            // 
            // lblMeasurementLastValue
            // 
            this.lblMeasurementLastValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMeasurementLastValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMeasurementLastValue.Location = new System.Drawing.Point(6, 135);
            this.lblMeasurementLastValue.Name = "lblMeasurementLastValue";
            this.lblMeasurementLastValue.Size = new System.Drawing.Size(179, 19);
            this.lblMeasurementLastValue.TabIndex = 6;
            this.lblMeasurementLastValue.Text = "[TIME]VALUE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Последнее значение";
            // 
            // btnMeasurementRefresh
            // 
            this.btnMeasurementRefresh.Location = new System.Drawing.Point(6, 90);
            this.btnMeasurementRefresh.Name = "btnMeasurementRefresh";
            this.btnMeasurementRefresh.Size = new System.Drawing.Size(179, 24);
            this.btnMeasurementRefresh.TabIndex = 4;
            this.btnMeasurementRefresh.Text = "Обновить";
            this.btnMeasurementRefresh.UseVisualStyleBackColor = true;
            this.btnMeasurementRefresh.Click += new System.EventHandler(this.btnMeasurementRefresh_Click);
            // 
            // nudMeasurementInterval
            // 
            this.nudMeasurementInterval.Location = new System.Drawing.Point(69, 64);
            this.nudMeasurementInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMeasurementInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMeasurementInterval.Name = "nudMeasurementInterval";
            this.nudMeasurementInterval.Size = new System.Drawing.Size(96, 20);
            this.nudMeasurementInterval.TabIndex = 3;
            this.nudMeasurementInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMeasurementInterval.ValueChanged += new System.EventHandler(this.nudMeasurementInterval_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Период, с";
            // 
            // chkMeasurementEnableTimer
            // 
            this.chkMeasurementEnableTimer.AutoSize = true;
            this.chkMeasurementEnableTimer.Location = new System.Drawing.Point(6, 46);
            this.chkMeasurementEnableTimer.Name = "chkMeasurementEnableTimer";
            this.chkMeasurementEnableTimer.Size = new System.Drawing.Size(109, 17);
            this.chkMeasurementEnableTimer.TabIndex = 1;
            this.chkMeasurementEnableTimer.Text = "Авто измерения";
            this.chkMeasurementEnableTimer.UseVisualStyleBackColor = true;
            this.chkMeasurementEnableTimer.CheckedChanged += new System.EventHandler(this.chkMeasurementEnableTimer_CheckedChanged);
            // 
            // cmbMeasurementSelection
            // 
            this.cmbMeasurementSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasurementSelection.FormattingEnabled = true;
            this.cmbMeasurementSelection.Location = new System.Drawing.Point(6, 19);
            this.cmbMeasurementSelection.Name = "cmbMeasurementSelection";
            this.cmbMeasurementSelection.Size = new System.Drawing.Size(179, 21);
            this.cmbMeasurementSelection.TabIndex = 0;
            this.cmbMeasurementSelection.SelectedIndexChanged += new System.EventHandler(this.cmbMeasurementSelection_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea14.Name = "ChartArea1";
            chartArea15.Name = "ChartArea2";
            chartArea16.Name = "ChartArea3";
            this.chart1.ChartAreas.Add(chartArea14);
            this.chart1.ChartAreas.Add(chartArea15);
            this.chart1.ChartAreas.Add(chartArea16);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(199, 6);
            this.chart1.Name = "chart1";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series14.Name = "Температура";
            series14.SmartLabelStyle.Enabled = false;
            series14.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series14.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series15.ChartArea = "ChartArea2";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series15.Name = "Влажность";
            series15.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series15.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series16.ChartArea = "ChartArea3";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series16.Name = "Освещенность";
            series16.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series16.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(515, 332);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.lstTcpConnections);
            this.tabPage3.Controls.Add(this.nudPort);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnStartTcpServer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(722, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tcp сервер";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Соединения";
            // 
            // lstTcpConnections
            // 
            this.lstTcpConnections.FormattingEnabled = true;
            this.lstTcpConnections.Location = new System.Drawing.Point(3, 63);
            this.lstTcpConnections.Name = "lstTcpConnections";
            this.lstTcpConnections.Size = new System.Drawing.Size(280, 277);
            this.lstTcpConnections.TabIndex = 3;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(163, 19);
            this.nudPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 20);
            this.nudPort.TabIndex = 2;
            this.nudPort.Value = new decimal(new int[] {
            5432,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "порт";
            // 
            // btnStartTcpServer
            // 
            this.btnStartTcpServer.Location = new System.Drawing.Point(3, 4);
            this.btnStartTcpServer.Name = "btnStartTcpServer";
            this.btnStartTcpServer.Size = new System.Drawing.Size(151, 35);
            this.btnStartTcpServer.TabIndex = 0;
            this.btnStartTcpServer.Text = "Запустить TCP сервер";
            this.btnStartTcpServer.UseVisualStyleBackColor = true;
            this.btnStartTcpServer.Click += new System.EventHandler(this.btnStartTcpServer_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(722, 344);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "История";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmbLogMeasurements);
            this.splitContainer2.Panel1.Controls.Add(this.cmbLogDates);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chart2);
            this.splitContainer2.Size = new System.Drawing.Size(716, 338);
            this.splitContainer2.SplitterDistance = 190;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmbLogMeasurements
            // 
            this.cmbLogMeasurements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLogMeasurements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogMeasurements.FormattingEnabled = true;
            this.cmbLogMeasurements.Location = new System.Drawing.Point(3, 30);
            this.cmbLogMeasurements.Name = "cmbLogMeasurements";
            this.cmbLogMeasurements.Size = new System.Drawing.Size(184, 21);
            this.cmbLogMeasurements.TabIndex = 1;
            this.cmbLogMeasurements.SelectedIndexChanged += new System.EventHandler(this.cmbLogMeasurements_SelectedIndexChanged);
            // 
            // cmbLogDates
            // 
            this.cmbLogDates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLogDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogDates.FormattingEnabled = true;
            this.cmbLogDates.Location = new System.Drawing.Point(3, 3);
            this.cmbLogDates.Name = "cmbLogDates";
            this.cmbLogDates.Size = new System.Drawing.Size(184, 21);
            this.cmbLogDates.TabIndex = 0;
            this.cmbLogDates.SelectedIndexChanged += new System.EventHandler(this.cmbLogDates_SelectedIndexChanged);
            // 
            // chart2
            // 
            chartArea13.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea13);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series13.Name = "History";
            series13.SmartLabelStyle.Enabled = false;
            series13.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series13.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart2.Series.Add(series13);
            this.chart2.Size = new System.Drawing.Size(522, 338);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Smart House Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCOMRespViewCount)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespHistoryLength)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMeasurementInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsdbSelectCom;
        private System.Windows.Forms.ToolStripStatusLabel lblCOMConnectionStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCOMSendText;
        private System.Windows.Forms.TextBox txtCOMSendBinary;
        private System.Windows.Forms.Button btnCOMSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudRespHistoryLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRespHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtCOMRespText;
        private System.Windows.Forms.TextBox txtCOMRespHex;
        private System.Windows.Forms.NumericUpDown nudCOMRespViewCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCOMRespViewDivide;
        private System.Windows.Forms.ComboBox cmbMeasurementSelection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox chkMeasurementEnableTimer;
        private System.Windows.Forms.NumericUpDown nudMeasurementInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMeasurementRefresh;
        private System.Windows.Forms.Label lblMeasurementLastValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbGraphMeasurements;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStartTcpServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstTcpConnections;
        private System.Windows.Forms.ToolStripStatusLabel lblServerStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblMyIp;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cmbLogDates;
        private System.Windows.Forms.ComboBox cmbLogMeasurements;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.ServiceProcess.ServiceController serviceController1;
    }
}

