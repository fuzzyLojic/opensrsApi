using System.Xml.Linq;              // to create XDocument
using System.Linq;
using System.IO;                    // to convert XDocument to API usable string using StringWriter
using System.Collections.Generic;

namespace OpenSRSLib
{
    public class XmlDoc
    {
        private string action;
        private XDocument baseDoc;

        public string XDocString
        {
            get
            {
                return xDocToString(baseDoc);
            }
        }

        public XmlDoc(string action){
            this.action = action;
            baseDoc = XmlDocument();
        }

        public void AddTopLevelItem(string key, string value){
            XElement topDt = baseDoc.Descendants("dt_assoc").First();
            XElement newItem = new XElement("item",
                new XAttribute("key", $"{key}"),
                value
            );
            topDt.Add(newItem);
        }

        public void AddItemList(string parentKey, string containerName, Dictionary<string, string> list){
            XElement topElement = baseDoc.Descendants("item").First(x => x.Attribute("key").Value == parentKey);
            XElement dt = new XElement(containerName);

            foreach (var item in list)
            {
                XElement newAttribute = new XElement("item",
                    new XAttribute("key", $"{item.Key}"),
                    $"{item.Value}"
                );
                dt.Add(newAttribute);
            }

            topElement.Add(dt);
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
                                        new XAttribute("key", "attributes")                                            
                                        
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
