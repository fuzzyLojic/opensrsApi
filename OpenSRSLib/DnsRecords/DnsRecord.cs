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