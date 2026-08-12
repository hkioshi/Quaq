using System.Net;
using System.Net.Sockets;
using Quaq.Services.Sistema;

namespace Quaq.Services.Desenvolvimento
{
    public class IpService
    {
        public static void MostrarIpLocal()
        {
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork &&
                    ip.ToString().StartsWith("192.168."))
                {
                    
                    UiService.LinhaUi("Ip",ip.ToString());
                }
            }

        }
    }
}