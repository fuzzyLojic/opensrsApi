using System.Collections.Generic;

namespace OpenSRSLib
{
    public class CNameRecord : DnsRecord
    {
        /// <summary>
        /// CName Record
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="subdomain">can be left out</param>
        public CNameRecord(string hostname, string subdomain = ""){
            this.Type = "CName";
            this.HostName = hostname;
            this.SubDomain = subdomain;

            record = new Dictionary<string, string>(){
                {"hostname", hostname},
                {"subdomain", subdomain}
            };
        }
    }
}