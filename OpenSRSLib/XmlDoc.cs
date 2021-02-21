using System.Xml.Linq;              // to create XDocument
using System.IO;                    // to convert XDocument to API usable string using StringWriter

namespace OpenSRSLib
{
    public class XmlDoc
    {
        private string action;
        private string domain;

        public XmlDoc(string action, string domain){
            this.action = action;
            this.domain = domain;
        }

        public XElement Domain {
            get {
                return new XElement("item",
                    new XAttribute("key", "domain"),
                    $"{domain}"
                );
            }
        }

        public string XDocString { 
            get {
                return xDocToString(XmlDocument());
            }
        }


        public XDocument XmlDocument(){
            return new XDocument(
                    new XDeclaration("1.0", "UTF-8", "no"),
                    new XDocumentType("OPS_envelope", null, "ops.dtd", null),
                    new XElement("OPS_envelope",
                        new XElement("header",
                            new XElement("version", "0.9")
                        ),
                        new XElement("body",
                            new XElement("data_block",
                                new XElement("dt_assoc",
                                    new XElement("item",
                                        new XAttribute("key", "protocol"),
                                        "XCP"),
                                    new XElement("item",
                                        new XAttribute("key", "action"),
                                        $"{action}"),              // proforming a lookup
                                    new XElement("item",
                                        new XAttribute("key", "object"),
                                        "DOMAIN"),              // of a domain
                                    new XElement("item",
                                        new XAttribute("key", "attributes"),
                                        new XElement("dt_assoc",
                                            // new XElement("item",
                                            //     new XAttribute("key", "domain"),
                                            //     $"{domain}" // domain being looked up
                                            // )
                                            this.Domain
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
        }

        // this function is needed because the ToString() method used directly on the
        // xDocument strips the XDeclaration
        public static string xDocToString(XDocument xDoc)
        {
            // Utf8StringWriter overrides utf-16 default encoding of StringWriter
            // This also ensures that the XDeclaration reads 'encoding="utf-8"'
            StringWriter writer = new Utf8StringWriter();
            xDoc.Save(writer, SaveOptions.None);
            return writer.ToString();
        }
    }
}

//             string xml = @"<?xml version ='1.0' encoding='UTF-8' standalone='no'?>
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
// </OPS_envelope>";