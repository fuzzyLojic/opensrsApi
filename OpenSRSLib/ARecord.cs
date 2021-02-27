using System.Text.RegularExpressions;

namespace OpenSRSLib
{
    public class ARecord
    {
        private string ip;

        public string IP { 
            get{
                return ip;
            }
        }

        public ARecord(string ip){
            if(Regex.IsMatch(ip, @"\b(?!255.255.255.255|10.0.0.0|100.64.0.0|127.0.0.0|169.254.0.0|172.16.0.0|192.0.0.0|192.0.2.0|192.88.99.0|192.168.0.0|198.18.0.0|198.51.100.0|203.0.113.0|224.0.0.0|240.0.0.0)((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.|$)){4}\b")){
                this.ip = ip;
            }
            else{
                Request.ErrorHandling("Invalid IP address", 13);
            }
        }
    }
}