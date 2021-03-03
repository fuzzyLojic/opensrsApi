using System.Collections.Generic;

namespace OpenSRSLib
{
    public class GetDnsRequest : Dns
    {        
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