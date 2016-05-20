using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace SmartHouseServer
{
    class SHServerTCPClient
    {
        SHServer server;
        SHServerTCPServer tcpServer;
        TcpClient client;
        Stream stream;
        BinaryReader reader;
        StreamReader readerS;
        BinaryReader writer;
        StreamWriter writerS;
        Thread readThread;
        
        bool stop = false;

        public SHServerTCPClient(TcpClient client, SHServerTCPServer tcpServer, SHServer server)
        {
            this.client = client;
            stream = client.GetStream();
            reader = new BinaryReader(stream);
            readerS = new StreamReader(stream);
            writer = new BinaryReader(stream);
            writerS = new StreamWriter(stream);
            this.server = server;
            this.tcpServer = tcpServer;
            
        }

        public void Stop()
        {
            stop = true;
        }
        public void Start()
        {
            readThread = new Thread(new ThreadStart(threadReadClientStream));
            readThread.Priority = ThreadPriority.BelowNormal;
            readThread.Start();
        }

        protected virtual void threadReadClientStream()
        {
            stop = false;
            while (!stop)
            {
                if (!client.Connected)
                {
                    Stop();
                    return;
                }
                if (client.Available > 0)
                {
                    ClientStreamRead();
                }                
            }

        }

        protected virtual void ClientStreamRead()
        {
            string header = readerS.ReadLine();
            string tmp;
            string[] tmp2;
            string[] tmp3;
            if (header.ToUpper() == "ANDROID APP V0")
            {
                tmp = readerS.ReadLine().ToLower();
                if (!tmp.StartsWith("commands-count:"))
                {
                    writerS.Write("Protocol error. Need commands-count header first");
                    writerS.Flush();
                    return;
                }
                tmp2 = tmp.Split(':');
                int cmdCount;
                if (!Int32.TryParse(tmp2[1].Trim(), out cmdCount))
                {
                    writerS.Write("Failed to get command count: Int32 parsing error\nArgument string:" + tmp + "\nError in [" + tmp2[1] + "]" );
                    writerS.Flush();
                    return;
                }
                StringBuilder response = new StringBuilder();
                for (int i = 0; i < cmdCount; i++)
                {
                    tmp = readerS.ReadLine().ToLower();
                    tmp2 = tmp.Split(':');
                    switch (tmp2[0])
                    {
                        case "get-last":
                            #region GET LAST
                            //temp/temperature/t|hum/humidity/h|illum/illumination/i|all
                            response.Append("ger-last: ");
                            tmp3 = tmp2[1].Split(',');
                            bool temperature = false;
                            bool humidity = false;
                            bool illumination = false;
                            string temp;
                            foreach (string str in tmp3)
                            {
                                temp = str.Trim().ToLower();
                                if (temp == "t" || temp == "temp" || temp == "temperature")
                                {
                                    temperature = true;
                                }
                                else if (temp == "i" || temp == "illum" || temp == "illumination")
                                {
                                    illumination = true;
                                }
                                else if (temp == "h" || temp == "humidity" || temp == "hum")
                                {
                                    humidity = true;
                                }
                                else if (temp == "all")
                                {
                                    temperature = true;
                                    humidity = true;
                                    illumination = true;
                                    break;
                                }

                            }
                            if (temperature)
                            {
                                MeasurementData lt = server.measurements["temperature"].Last;
                                if (lt != null)
                                {
                                    response.Append("temperature=" + lt.ToString() + ",");
                                }
                            }
                            if (humidity)
                            {
                                MeasurementData lt = server.measurements["humidity"].Last;
                                if (lt != null)
                                {
                                    response.Append("humidity=" + lt.ToString() + ",");
                                }
                            }
                            if (illumination)
                            {
                                MeasurementData lt = server.measurements["illumination"].Last;
                                if (lt != null)
                                {
                                    response.Append("illumination=" + lt.ToString() + ",");
                                }
                            }
                            response.Append("\n");
                            #endregion
                            break;
                        case "refresh":
                            #region REFRESH
                            response.Append("refresh: complete\n");
                            tmp3 = tmp2[1].Split(',');
                            temperature = false;
                            humidity = false;
                            illumination = false;
                            foreach (string str in tmp3)
                            {
                                temp = str.Trim().ToLower();
                                if (temp == "t" || temp == "temp" || temp == "temperature")
                                {
                                    temperature = true;
                                }
                                else if (temp == "i" || temp == "illum" || temp == "illumination")
                                {
                                    illumination = true;
                                }
                                else if (temp == "h" || temp == "humidity" || temp == "hum")
                                {
                                    humidity = true;
                                }
                                else if (temp == "all")
                                {
                                    temperature = true;
                                    humidity = true;
                                    illumination = true;
                                    break;
                                }

                            }
                            if (temperature)
                            {
                                server.measurements["temperature"].Refresh();

                            }
                            if (humidity)
                            {
                                server.measurements["humidity"].Refresh();

                            }
                            if (illumination)
                            {
                                server.measurements["illumination"].Refresh();

                            }
                            #endregion
                            break;
                        case "get-list":
                            #region GET LIST
                            response.Append("get-list: ");
                            tmp3 = tmp2[1].Split(',');
                            temperature = false;
                            humidity = false;
                            illumination = false;
                            int count = 10;
                            int rcount = count;
                            if (!Int32.TryParse(tmp3[0], out count))
                            {
                                response.Append("get-list-error: Failed to parse Int32\nArgument: '" + tmp3[0] + "'");
                            }
                            for (int j = 1; j < tmp3.Length; j++)
                            {
                                temp = tmp3[j].Trim().ToLower();
                                if (temp == "t" || temp == "temp" || temp == "temperature")
                                {
                                    temperature = true;
                                }
                                else if (temp == "i" || temp == "illum" || temp == "illumination")
                                {
                                    illumination = true;
                                }
                                else if (temp == "h" || temp == "humidity" || temp == "hum")
                                {
                                    humidity = true;
                                }
                                else if (temp == "all")
                                {
                                    temperature = true;
                                    humidity = true;
                                    illumination = true;
                                    break;
                                }

                            }
                            if (temperature)
                            {
                                List<MeasurementData> hist = server.measurements["temperature"].History;
                                rcount = count;
                                if (hist.Count < count)
                                {
                                    rcount = hist.Count;
                                }
                                response.Append("temperature{");
                                for (int j = hist.Count - 1; j >= hist.Count - rcount; j--)
                                {
                                    response.Append(hist[j].ToString() + ";");
                                }
                                response.Append("},");

                            }
                            if (humidity)
                            {
                                List<MeasurementData> hist = server.measurements["humidity"].History;
                                rcount = count;
                                if (hist.Count < count)
                                {
                                    rcount = hist.Count;
                                }
                                response.Append("humidity{");
                                for (int j = hist.Count - 1; j >= hist.Count - rcount; j--)
                                {
                                    response.Append(hist[j].ToString() + ";");
                                }
                                response.Append("},");

                            }
                            if (illumination)
                            {
                                List<MeasurementData> hist = server.measurements["illumination"].History;
                                rcount = count;
                                if (hist.Count < count)
                                {
                                    rcount = hist.Count;
                                }
                                response.Append("illumination{");
                                for (int j = hist.Count - 1; j >= hist.Count - rcount; j--)
                                {
                                    response.Append(hist[j].ToString() + ";");
                                }
                                response.Append("},");

                            }
                            response.Append("\n");
                            #endregion
                            break;
                        case "set-timer":
                            #region SET TIMER
                            response.Append("set-timer: complete\n");
                            tmp3 = tmp2[1].Split(',');
                            temperature = false;
                            humidity = false;
                            illumination = false;

                            temp = tmp3[0].Trim().ToLower();
                            int interval = 10;
                            if (!Int32.TryParse(tmp3[1], out interval))
                            {
                                response.Append("set-timer-error: Failed to parse Int32\nArgument: '" + tmp3[1] + "'");
                            }
                            if (temp == "t" || temp == "temp" || temp == "temperature")
                            {
                                temp = "temperature";
                            }
                            else if (temp == "i" || temp == "illum" || temp == "illumination")
                            {
                                temp = "illumination";
                            }
                            else if (temp == "h" || temp == "humidity" || temp == "hum")
                            {
                                temp = "humidity";
                            }
                            else if (temp == "all")
                            {
                                
                                if (interval == 0)
                                {
                                    server.measurements["temperature"].StopMeasurementTimer();
                                    server.measurements["humidity"].StopMeasurementTimer();
                                    server.measurements["illumination"].StopMeasurementTimer();
                                }
                                else
                                {
                                    server.measurements["temperature"].StartMeasurementTimer();
                                    server.measurements["temperature"].SetMeasurementInterval(interval);
                                    server.measurements["illumination"].StartMeasurementTimer();
                                    server.measurements["illumination"].SetMeasurementInterval(interval);
                                    server.measurements["humidity"].StartMeasurementTimer();
                                    server.measurements["humidity"].SetMeasurementInterval(interval);
                                }
                                break;
                            }
                            if (interval == 0)
                            {
                                server.measurements[temp].StopMeasurementTimer();
                            }
                            else
                            {
                                server.measurements[temp].StartMeasurementTimer();
                                server.measurements[temp].SetMeasurementInterval(interval);
                            }

                            #endregion
                            break;
                        default:
                            response.Append("Unknown header: '" + tmp2[0] + "'\n");
                            break;
                    }
                }
                writerS.Write(response.ToString());
                writerS.Flush();
            }
            else
            {
                writerS.Write("Unexpected header. Please, wait for new version");
                writerS.Flush();
            }
       
        }
    }
}
