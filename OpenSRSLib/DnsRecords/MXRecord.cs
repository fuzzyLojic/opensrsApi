using System.Collections.Generic;

namespace OpenSRSLib
{
    public class MXRecord : DnsRecord
    {
        public MXRecord(string hostname, ushort priority, string subdomain = ""){
            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"priority", priority.ToString()},
                {"subdomain", subdomain}
            };
        }
    }
}