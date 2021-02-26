using System.Collections.Generic;

// Determines the availablity of a domain
namespace OpenSRSLib
{
    public class Lookup : Request
    {
        private string domain;
        private short nocache;

        // Lookup Contructor
        // takes string "domain" - domain name to be seached for availability
        // optional nocache - 0 = looks in OpenSRS cached results, 1 = looks to applicable registry
        public Lookup(string domain, short nocache = 0){
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

// Example of complete LOOKUP xml request:
// <?xml version ='1.0' encoding='UTF-8' standalone='no'?>
// <!DOCTYPE OPS_envelope SYSTEM 'ops.dtd'>
// <OPS_envelope>
// <header>      
//     <version>0.9</version>
// </header>
// <body>
// <data_block>      
//     <dt_assoc>      
//         <item key=""protocol"">XCP</item>       
//         <item key=""action"">LOOKUP</item>        
//         <item key=""object"">DOMAIN</item>         
//         <item key=""attributes"">          
//             <dt_assoc>          
//                 <item key=""domain"">weomedia.com</item>           
//             </dt_assoc>           
//         </item>           
//     </dt_assoc>
// </data_block>
// </body>
// </OPS_envelope>