
namespace OpenSRSLib
{
    public class Lookup : Request
    {
        private string domain;
        private short nocache;

        protected override string Xml{
            get{
                xml = new XmlDoc("LOOKUP", "weomedia.com").XDocString;
                return xml;
            }
        }

        public Lookup(string domain, short nocache = 0){
            this.domain = domain;
            this.nocache = nocache;
        }
    }
}