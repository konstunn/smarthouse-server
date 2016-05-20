using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using SmartHouseServer;

namespace Smart_House_Server_Console
{
    class Program
    {
        static SmartHouseServer.SHServer server;
        static void Main(string[] args)
        {
            server = new SmartHouseServer.SHServer();
            Console.WriteLine("aaaa");
            
            ConnectPort();


            server.measurements["illumination"].SetMeasurementInterval(500);
            string cmd;
            string temp;
            while (true)
            {
                cmd = Console.ReadLine().Trim().ToLower();
                if (cmd == "last")
                {
                    temp = Console.ReadLine().Trim().ToLower();
                    if (!server.measurements.ContainsKey(temp))
                        continue;
                    Measurement mea = server.measurements[temp];
                    Console.WriteLine("{0,-10}{1,-10}", "Дата", mea.Name);
                    Console.WriteLine("{0,-10:T}{1,-10}", mea.Last.CreationTime, mea.Last.Value);
                    Console.WriteLine("\n");
                }
                else if (cmd == "list")
                {
                    temp = Console.ReadLine().Trim().ToLower();
                    if (!server.measurements.ContainsKey(temp))
                        continue;
                    Measurement mea = server.measurements[temp];
                    Console.WriteLine("{0,-10}{1,-10}", "Дата", mea.Name);
                    foreach (MeasurementData data in mea.History)
                    {
                        Console.WriteLine("{0,-10:T}{1,-10}", data.CreationTime, data.Value);
                    }
                    Console.WriteLine("\n");
                }
                else if (cmd == "set interval")
                {
                    temp = Console.ReadLine().Trim().ToLower();
                    if (!server.measurements.ContainsKey(temp))
                        continue;
                    Measurement mea = server.measurements[temp];
                    Console.WriteLine("Введите интервал измерений для [{0}] в с", mea.Name);
                    temp = Console.ReadLine().Trim();
                    mea.SetMeasurementInterval(Convert.ToDouble(temp) * 1000);
                }
                else if (cmd == "start")
                {
                    temp = Console.ReadLine().Trim().ToLower();
                    if (!server.measurements.ContainsKey(temp))
                        continue;
                    Measurement mea = server.measurements[temp];
                    mea.StartMeasurementTimer();
                }
                else if (cmd == "stop")
                {
                    temp = Console.ReadLine().Trim().ToLower();
                    if (!server.measurements.ContainsKey(temp))
                        continue;
                    Measurement mea = server.measurements[temp];
                    mea.StopMeasurementTimer();
                }
                else if (cmd == "start all")
                {
                    foreach (Measurement mea in server.measurements.Values)
                    {
                        mea.StartMeasurementTimer();
                    }
                }
                else if (cmd == "stop all")
                {
                    foreach (Measurement mea in server.measurements.Values)
                    {
                        mea.StopMeasurementTimer();
                    }
                }
                else if (cmd == "exit")
                {
                    break;
                }
                else if (cmd == "connect")
                {
                    ConnectPort();
                }
                else
                {
                }
            }
            Console.WriteLine("Ожидание нажатия клавиши для завершения работы");
            Console.ReadKey();
        }

        static void cmdHelp()
        {
            
        }

        static void ConnectPort()
        {
            Console.Clear();
            Console.WriteLine("Доступные COM - порты:");
            string[] portnames = SerialPort.GetPortNames();
            foreach (string str in portnames)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("К какому подключаемся?");
            string comName = Console.ReadLine();
            SerialPort com1 = new SerialPort(comName, 115200, Parity.None, 8, StopBits.One);
            server.ConnectToMK(com1);

        }
    }
}
