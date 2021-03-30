using System.Collections.Generic;
using System.Net;

namespace OpenSRSLib
{
    public class DnsRecord
    {
        protected Dictionary<string, string> record;

        public Dictionary<string, string> Record { 
            get{
                return record;
            }
        }

        public string Type { get; set; }
        public string IpAddress { get; set; }
        public string HostName { get; set; }
        public string Priority { get; set; }
        public string Weight { get; set; }
        public string Port { get; set; }
        public string Text { get; set; }
        public string SubDomain { get; set; }

        protected void ValidateIP(string ipAddress){
            IPAddress throwAway;
            if (IPAddress.TryParse(ipAddress, out throwAway)){
                return;
            }
            else{
                Request<bool>.ErrorHandling("Invalid IP address", 13);
            }
        }
    }
}