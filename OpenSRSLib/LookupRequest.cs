using System.Collections.Generic;

// Determines the availablity of a domain
namespace OpenSRSLib
{
    public class LookupRequest : Request
    {
        private string domain;
        private ushort nocache;

        // LookupRequest Contructor
        // takes string "domain" - domain name to be seached for availability
        // optional nocache - 0 = looks in OpenSRS cached results, 1 = looks to applicable registry
        public LookupRequest(string domain, ushort nocache = 0){
            this.domain = domain;
            this.nocache = nocache;
            xml = BuildXML();
        }

        // BuildXML: builds XML request for Lookup
        protected override string BuildXML(){
            XmlDoc doc = new XmlDoc("lookup");
            Dictionary<string, string> attributes = new Dictionary<string, string>()
            {
                {"domain", domain},
                {"no_cache", nocache.ToString()}
            };

            doc.AddItemList("attributes", "dt_assoc", attributes);
            
            return doc.XDocString;
        }
    }
}