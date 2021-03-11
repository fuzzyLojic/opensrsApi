using System;
using System.Text;
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

        // XMLDoc Constructor
        // takes string "action" (ie. LOOKUP, REGISTER, etc)
        // assembles base of xml request object
        public XmlDoc(string action){
            this.action = action;
            baseDoc = XmlDocument();
        }

        // Adds an Element to the top level <data_block><dt_assoc></></>
        // of the form <item key="key">value</item>
        public void AddTopLevelItem(string key, string value){
            XElement topDt = baseDoc.Descendants("dt_assoc").First();
            XElement newItem = new XElement("item",
                new XAttribute("key", key),
                value
            );
            topDt.Add(newItem);
        }

        // Creates a list of Elements within the Element 
        // <item key=parentKey>
        public void AddItemList(string parentKey, string containerName, Dictionary<string, string> list){
            XElement parentElement = baseDoc.Descendants("item").First(x => x.Attribute("key").Value == parentKey);
            XElement dt = CreateElementList(containerName, list);

            parentElement.Add(dt);
        }

        // Creates a list of Elements within the Element 
        // <item key=baseKey><some_container><item key=parentKey>
        public void AddItemSubList(string baseKey, string parentKey, string containerName, Dictionary<string, string> list){
            XElement baseElement = baseDoc.Descendants("item").First(x => x.Attribute("key").Value == baseKey);
            XElement parentElement = baseElement.Descendants("item").First(x => x.Attribute("key").Value == parentKey);
            XElement dt = CreateElementList(containerName, list);

            parentElement.Add(dt);
        }

        // Creates a new Element named containerName and inserts a list of Elements
        // of the form <item key="keyName">value</item>
        private XElement CreateElementList(string containerName, Dictionary<string, string> list){
            XElement dt = new XElement(containerName);

            foreach (var item in list)
            {
                XElement newAttribute = new XElement("item",
                    new XAttribute("key", item.Key),
                    item.Value
                );
                dt.Add(newAttribute);
            }

            return dt;
        }

        // base document for all requests
        private XDocument XmlDocument(){
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
                                        action),              // proforming a lookup
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
        private static string xDocToString(XDocument xDoc)
        {
            // Utf8StringWriter overrides utf-16 default encoding of StringWriter
            // This also ensures that the XDeclaration reads 'encoding="utf-8"'
            StringWriter writer = new Utf8StringWriter();
            xDoc.Save(writer, SaveOptions.None);
            return writer.ToString();
        }

        /*** End Request Block ***/

        /*** Begin Response Block ***/
        
        // process the results of a Request into a JSON formatted string
        public static string ToJson(string results){
            XDocument xString = XDocument.Parse(results);

            XElement el = xString.Descendants("item").First();
            StringBuilder element = JsonHelper(el);
            StringBuilder jsonString = new StringBuilder("{" + element + "}");
            string json = jsonString.ToString();
            json.Replace("\n", "");
            return json;
        }

        // recursive JSON string builder
        private static StringBuilder JsonHelper(XElement el){
            StringBuilder jsonString = new StringBuilder("");
            if(!el.HasElements){    // does not have descendents
                jsonString.Append("\"" + el.Attribute("key").Value + "\": \"" + el.Value + "\"");
            }
            else{   // has descendents
                StringBuilder element = el.Descendants("item").Count() > 0 ? JsonHelper(el.Descendants("item").First()) : new StringBuilder("");
                jsonString.Append("\"" + el.Attribute("key").Value + "\": {" + element + "}");
            }

            if(el.ElementsAfterSelf().Count() > 0){ // has more sibling elements
                StringBuilder element = JsonHelper(el.ElementsAfterSelf("item").First());
                return jsonString.Append($",{element}");
            }
            else{   // no more sibling elements
                return jsonString;
            }
        }

        // takes Request results XML string and returns a Dictionary
        // of key names and values
        // ex: <item key="moop">floop</item> returns
        // { "moop", "floop" }
        public static Dictionary<string, string> ProcessToDictionary(string results){
            var doc = XDocument.Parse(results);
            Dictionary<string, string> processedResults = new Dictionary<string, string>();
            foreach (var item in doc.Descendants("item"))
            {
                if(item.HasElements){   // skip items with decendents
                    continue;
                }
                int i;
                string key;

                string keyName = item.Attribute("key").Value;
                if(processedResults.TryGetValue(keyName, out key)){  // check for duplicate keys
                    string[] s = keyName.Split("-");                   // try to split the duplicated key string
                    if(s.Length > 1 && Int32.TryParse(s[1], out i)){    // if there is a number at the end of it
                        processedResults.Add($"{s[0]}-{++i}", item.Value); // new key incremented from previous
                    }
                    else{                                               // no number at the end
                        processedResults.Add($"{s[0]}-1", item.Value);  // add "-1"
                    };
                }
                else{
                    processedResults.Add(keyName, item.Value);
                }
            }

            return processedResults;
        }


        public static Response CreateResponse(string results){
            var doc = XDocument.Parse(results);
            bool isSuccess = false;
            if(doc.Descendants("item").Where(x => x.Attribute("key").Value == "is_success").First().Value == 1.ToString()){
                isSuccess = true;
            }
            int responseCode = Convert.ToInt32(doc.Descendants("item").Where(x => x.Attribute("key").Value == "response_code").First().Value);
            string responseText = doc.Descendants("item").Where(x => x.Attribute("key").Value == "response_text").First().Value;


            return new Response(results, isSuccess, responseCode, responseText);
        }

        /*** End Response Block ***/
    }
}
