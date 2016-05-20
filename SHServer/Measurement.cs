using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Diagnostics;
namespace SmartHouseServer
{
    public class MeasurementData
    {
        protected double value;
        protected DateTime creationTime;

        public double Value
        {
            get { return value; }
        }
        public DateTime CreationTime
        {
            get { return creationTime; }
        }

        public MeasurementData(double val)
        {
            value = val;
            creationTime = DateTime.Now;
        }
        public MeasurementData(double val, DateTime time)
        {
            value = val;
            creationTime = time;
        }
        public override string ToString()
        {
            return string.Format("[{0:T}]{1}", CreationTime, Value);
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(CreationTime.ToBinary());
            writer.Write(Value);
        }
        public MeasurementData(BinaryReader reader)
        {
            creationTime = DateTime.FromBinary(reader.ReadInt64());
            value = reader.ReadDouble();

        }


    }

    public class Measurement
    {

        public delegate void DataReceived(MeasurementData data);
        public delegate void AddChartPoint(MeasurementData data, string key);
        public delegate void RemoveChartPointAt(int index, string key);

        public AddChartPoint AddPoint;
        public RemoveChartPointAt RemovePoint;
        public event DataReceived OnDataReceived;

        protected Timer timer = new Timer();

        protected byte cmd;
        public byte Command
        {
            get { return cmd; }
        }
        
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Key { get; set; }
        public int MaxSeriesPointsCount { get; set; }
        int seriesPointsCount;

        public List<MeasurementData> History = new List<MeasurementData>();
        public MeasurementData Last
        {
            get
            {
                if (History.Count > 0)
                    return History[History.Count - 1];
                else
                    return null;
            }
        }
        public bool AutoMeasurement
        {
            get { return timer.Enabled; }
            set
            {
                if (value)
                    StartMeasurementTimer();
                else
                    StopMeasurementTimer();
            }
        }
        /// <summary>
        /// Возвращает или задает интервал измерений в секундах
        /// </summary>
        public int AutoMeasurementInterval
        {
            get { return (int)(timer.Interval / 1000); }
            set { SetMeasurementInterval((double)value * 1000); }
        }
        protected SHServer server;


        public Measurement(byte cmd, SHServer server, string name, string unit, string key)
        {
            //server.OnDataReceived += server_OnDataReceived;
            seriesPointsCount = 0;
            Name = name;
            Unit = unit;
            Key = key;
            this.server = server;
            this.cmd = cmd;
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 5000;
            MaxSeriesPointsCount = 50;
        }

        public void Refresh()
        {
            Debug.Print("{0} request", Name);
            server.SendCommandToMK(cmd);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.Print("{0} request", Name);
            server.SendCommandToMK(cmd);
        }

        

        public void DataRead(BinaryReader reader)
        {
            byte cmd = 0;

            if (reader.BaseStream as MemoryStream != null)
            {
                if (((MemoryStream)reader.BaseStream).Length == 0)
                    return;
                if (((MemoryStream)reader.BaseStream).Position >= ((MemoryStream)reader.BaseStream).Length - 1)
                    return;
            }
            cmd = reader.ReadByte();

            if (cmd != this.cmd)
            {
                reader.BaseStream.Seek(-1, SeekOrigin.Current);
                return;
            }
            double value = (double)reader.ReadInt16();
            MeasurementData val = new MeasurementData(value);
            History.Add(val);
            
            if (History.Count > MaxSeriesPointsCount * 2)
            {
                History.RemoveRange(0, MaxSeriesPointsCount);
                server.Logger.WriteAndCheckMeasurements(Key, History);
            }
            if (OnDataReceived != null)
            {
                OnDataReceived(val);
            }


            if (AddPoint != null)
            {
                //Debug.Print("AddPoint {0} {1}", Name, Last);
                AddPoint(Last, Name);
                seriesPointsCount++;
                if (seriesPointsCount > MaxSeriesPointsCount && RemovePoint != null)
                {
                    int d = seriesPointsCount - MaxSeriesPointsCount;
                    for (int i = 0; i < d; i++)
                    {
                        //Debug.Print("RemovePoint {0} {1}", Name, i);
                        RemovePoint(0, Name);
                    }
                    seriesPointsCount -= d;
                }
            }


        }

        public void WriteLogData()
        {
            server.Logger.WriteAndCheckMeasurements(Key, History);
        }

        public void StartMeasurementTimer()
        {
            Console.WriteLine("{0}: таймер запущен", Name);
            timer.Start();
        }
        public void StopMeasurementTimer()
        {
            Console.WriteLine("{0}: таймер остановлен", Name);
            timer.Stop();
        }
        public void SetMeasurementInterval(double interval)
        {
            timer.Interval = interval; 
        }

        
    }
}
