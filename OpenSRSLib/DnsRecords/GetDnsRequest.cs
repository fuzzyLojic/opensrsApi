using System.Collections.Generic;
using System.Collections.Specialized;

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

        protected override Dictionary<string, string> ProcessedResults(string results)
        {
            // Create DNS Record objects to use for Update by passing to SetDnsRequest
            // string recKey;
            Dictionary<string, string> reqResults = XmlDoc.ProcessResponse(results);
            // OrderedDictionary ordered = new OrderedDictionary();
            // foreach (var item in reqResults)
            // {
            //     ordered.Add(item.Key, item.Value);
            // }
            // if(ordered.Contains("MX")){
            //     int
            // }
            return reqResults;
        }
    }
}