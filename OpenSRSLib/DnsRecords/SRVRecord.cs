using System.Collections.Generic;

namespace OpenSRSLib
{
    public class SRVRecord : DnsRecord
    {
        public SRVRecord(string hostName, ushort priority, ushort weight, ushort port, string subdomain = ""){
            record = new Dictionary<string, string>(){
                {"hostname", hostName},
                {"priority", priority.ToString()},
                {"weight", weight.ToString()},
                {"port", port.ToString()},
                {"subdomain", subdomain}
            };
        }
    }
}