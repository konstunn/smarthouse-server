using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace SmartHouseServer
{
    public class SHServerTCPServer
    {
        TcpListener listener;
        SHServer server;
        List<SHServerTCPClient> clients = new List<SHServerTCPClient>();

        public static string GetMyIp()
        {
            string outer_ip = "?";
            string inner_ip = "?";
            string host_name = "?";
            try
            {
                HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create("http://ai12.tk/ip.php");
                proxy_request.Method = "GET";
                proxy_request.ContentType = "application/x-www-form-urlencoded";
                proxy_request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
                proxy_request.KeepAlive = true;
                HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
                string html = "";
                using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(1251)))
                    html = sr.ReadToEnd();
                html = html.Trim();
                outer_ip = html;
            }
            catch { }
            try
            {
                IPHostEntry iphe = Dns.GetHostEntry(host_name = Dns.GetHostName());
                inner_ip = iphe.AddressList[0].MapToIPv4().ToString();
                string tmp;
                for (int i = 0; i < iphe.AddressList.Length; i++)
                {
                    tmp = iphe.AddressList[i].ToString();
                    if (tmp.StartsWith("192"))
                    {
                        inner_ip = tmp;
                        break;
                    }
                }
            }
            catch { }
            return host_name + " / " + outer_ip + " / " + inner_ip;
        }


        public void StartListener(int port, SHServer server)
        {
            listener = new TcpListener(System.Net.IPAddress.Any, port);
            
            listener.Start();
            listener.BeginAcceptTcpClient(AcceptTcpClient, listener);
            this.server = server;
        }
        public void AcceptTcpClient(IAsyncResult ar)
        {
            try
            {
                TcpListener listener = (TcpListener)ar.AsyncState;
                TcpClient client = listener.EndAcceptTcpClient(ar);
                SHServerTCPClient shClient = new SHServerTCPClient(client, this, server);
                clients.Add(shClient);
                shClient.Start();


                this.listener.BeginAcceptTcpClient(AcceptTcpClient, this.listener);
            }
            catch (Exception ex)
            {
                Debug.Print("TcpListener:AcceptTcpClient\n" + ex.Message);
            }
        }
        public void StopListener()
        {
            
            listener.Stop();
            listener = null;
            
        }
    }
}
