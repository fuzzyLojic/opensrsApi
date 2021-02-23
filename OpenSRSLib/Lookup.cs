using System.Collections.Generic;

// Determines the availablity of a domain
namespace OpenSRSLib
{
    public class LookupAvailabilty : Request
    {
        private string domain;
        private short nocache;

        protected override string Xml{
            get{
                XmlDoc doc = new XmlDoc("LOOKUP");
                Dictionary<string, string> attributes = new Dictionary<string, string>()
                {
                    {"domain", domain},
                    {"no_cache", nocache.ToString()}
                };
                doc.AddItemList("attributes", "dt_assoc", attributes);
                
                return doc.XDocString;
            }
        }

        public LookupAvailabilty(string domain, short nocache = 0){
            this.domain = domain;
            this.nocache = nocache;
        }
    }
}

// Example:
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