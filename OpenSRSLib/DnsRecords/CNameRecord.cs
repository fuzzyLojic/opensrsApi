using System.Collections.Generic;

namespace OpenSRSLib
{
    public class CNameRecord : DnsRecord
    {
        public string HostName { get; set; }
        public string SubDomain { get; set; }

        /// <summary>
        /// CName Record
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="subdomain">can be left out</param>
        public CNameRecord(string hostname, string subdomain = ""){
            this.HostName = hostname;
            this.SubDomain = subdomain;

            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"subdomain", subdomain}
            };
        }
    }
}