using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmartHouseServer
{
    public class SHServerLogger
    {
        
        public SHServerLogger()
        {
            
        }

        public void WriteMeasurement(string measurement, MeasurementData data)
        {
            DateTime date = DateTime.Now;
            if (!Directory.Exists("data\\" + date.ToShortDateString()))
            {
                Directory.CreateDirectory("data\\" + date.ToShortDateString());
            }
            Stream file;
            if (!File.Exists("data\\" + date.ToShortDateString() + "\\" + measurement + ".bl"))
            {
                file = File.Create("data\\" + date.ToShortDateString() + "\\" + measurement + ".bl");
            }
            else
            {
                file = File.Open("data\\" + date.ToShortDateString() + "\\" + measurement + ".bl", FileMode.Append);
            }
            BinaryWriter writer = new BinaryWriter(file);
            data.Write(writer);
            file.Close();
        }
        public void WriteMeasurements(string measurement, List<MeasurementData> data)
        {
            DateTime date = DateTime.Now;
            string folder = "data\\" + date.ToShortDateString();
            string filename = folder + "\\" + measurement + ".bl";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Stream file;
            if (!File.Exists(filename))
            {
                file = File.Create(filename);
            }
            else
            {
                file = File.Open(filename, FileMode.Append);
            }
            BinaryWriter writer = new BinaryWriter(file);
            for (int i = 0; i < data.Count; i++)
            {
                data[i].Write(writer);
            }
            
            file.Close();

        }
        public void WriteAndCheckMeasurements(string measurement, List<MeasurementData> data)
        {
            if (data.Count <= 0)
                return;
            DateTime date = DateTime.Now;
            string folder = "data\\" + date.ToShortDateString();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            Stream file;
            if (!File.Exists(folder + "\\" + measurement + ".bl"))
            {
                WriteMeasurements(measurement, data);
                return;
            }
            string fname, fnametmp;
            file = File.OpenRead(fname = folder + "\\" + measurement + ".bl");
            Stream fileTmp = File.Create(fnametmp = folder + "\\" + measurement + ".tmp");
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(fileTmp);
            long count = (file.Length / (sizeof(long) + sizeof(double)));
            MeasurementData tmp;
            int j;
            bool write = true;
            for (long i = 0; i < count; i++)
            {
                write = true;
                tmp = new MeasurementData(reader);
                for (j = 0; j < data.Count; j++)
                {
                    if (data[j].CreationTime == tmp.CreationTime)
                    {
                        write = false;
                        break;
                    }
                }
                if (write)
                {
                    tmp.Write(writer);
                }
            }
            for (j = 0; j < data.Count; j++)
            {
                data[j].Write(writer);
            }
            file.Close();
            fileTmp.Close();
            File.Delete(fname);
            File.Move(fnametmp, fname);

        }

        public List<MeasurementData> GetMeasurements(string measurement, string date)
        {
            if (!Directory.Exists("data\\" + date))
            {
                return null;
            }
            Stream file;
            if (!File.Exists("data\\" + date + "\\" + measurement + ".bl"))
            {
                return null;
            }
            file = File.OpenRead("data\\" + date + "\\" + measurement + ".bl");
            BinaryReader reader = new BinaryReader(file);
            long count = (file.Length / (sizeof(long) + sizeof(double)));
            List<MeasurementData> lst = new List<MeasurementData>();
            for (long i = 0; i < count; i++)
            {
                lst.Add(new MeasurementData(reader));
            }
            return lst;
        }

        public DateTime[] GetAvailableDates()
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
                return null;
            }
            DirectoryInfo di = new DirectoryInfo("data");
            DirectoryInfo[] dis = di.GetDirectories();
            DateTime dt;
            List<DateTime> dirs = new List<DateTime>();
            for (int i = 0; i < dis.Length; i++)
            {
                if (DateTime.TryParse(dis[i].Name, out dt))
                {
                    dirs.Add(dt);
                }
            }
            return dirs.ToArray();
        }

        
    }
    
}
