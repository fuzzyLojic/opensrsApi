using System;
using System.Collections.Generic;

// Returns DNS information for requested domain

namespace OpenSRSLib
{
    public class GetDnsRequest : Request<GetDnsResponse>
    {
        private string domain;

        /// <summary>
        /// Get Zone file for domain if it exists
        /// </summary>
        /// <param name="domain"></param>
        public GetDnsRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("get_dns_zone");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            return doc.XDocString;
        }
    }
}