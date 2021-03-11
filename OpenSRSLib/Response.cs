using System.Xml.Linq;

namespace OpenSRSLib
{
    public class Response
    {
        protected string responseString;
        protected bool isSuccess;
        protected int responseCode;
        protected string responseText;

        public new string ToString { 
            get
            {
                return responseString;
            }
        }

        public bool IsSuccess { 
            get
            {
                return isSuccess;
            }
        }

        public int ResponseCode { 
            get
            {
                return responseCode;
            }
        }

        public string ResponseText { 
            get
            {
                return responseText;
            }
        }

        public string ToJson { 
            get
            {
                return XmlDoc.ToJson(responseString);
            }
        }

        public XDocument ToXDoc {
            get
            {
                return XDocument.Parse(responseString);
            }
        }

        public Response(string responseString, bool isSuccess, int responseCode, string responseText){
            this.responseString = responseString;
            this.isSuccess = isSuccess;
            this.responseCode = responseCode;
            this.responseText = responseText;
        }
    }
}