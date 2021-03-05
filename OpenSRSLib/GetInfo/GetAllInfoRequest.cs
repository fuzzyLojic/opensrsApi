using System.Collections.Generic;

namespace OpenSRSLib
{
    public class GetAllInfoRequest : GetInfo
    {
        public GetAllInfoRequest(string domain){
            this.domain = domain;
            xml = BuildXML();
        }

        protected override string BuildXML()
        {
            XmlDoc doc = new XmlDoc("GET");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"type", "all_info"}
            };
            doc.AddItemList("attributes", "dt_assoc", attributes);

            doc.AddTopLevelItem("registrant_ip", this.GetIp());

            return doc.XDocString;
        }
    }
}