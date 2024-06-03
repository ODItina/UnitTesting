using MockNetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MockNetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dnsService;
        public NetworkService(IDNS dnsService)
        {
            _dnsService = dnsService;                
        }
        public string SendPing()
        {
            string returnValue = "Failed: Ping not Sent!";
            //SearchDNS();
            var result = _dnsService.SendDNS();
            //BuildPacket();
            if (result == true)
                returnValue =  "Success: Ping Sent!";

            return returnValue;
        }
        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl =1,

            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pings = new List<PingOptions>()
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl =1,

                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl =1,

                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl =1,

                }
            };


            return pings.AsEnumerable();
        }
    }
}
