using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace OpenSRSLib
{
    public class ContactSet
    {
        private Dictionary<string, string> set;

        public Dictionary<string,string> Set { 
            get{
                return set;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrgName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        /// <summary>
        /// Creates a US contact set for use in registering/transferring a domain
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="orgName"></param>
        /// <param name="phone"></param>
        /// <param name="fax">can be null</param>
        /// <param name="email"></param>
        /// <param name="address1"></param>
        /// <param name="address2">can be null</param>
        /// <param name="address3">can be null</param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postalCode"></param>
        public ContactSet(string firstName, string lastName, string orgName, string phone, string fax, string email, string address1, string address2, string address3, string city, string state, string postalCode){
            ValidatePhone(phone);
            ValidateEmail(email);
            ValidateState(state);
            ValidateZip(postalCode);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.OrgName = orgName;
            this.Phone = phone;
            this.Email = email;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Address3 = address3;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;

            set = new Dictionary<string, string>(){
                {"first_name", firstName},
                {"last_name", lastName},
                {"org_name", orgName},
                {"phone", phone},
                {"email", email},
                {"address1", address1},
                {"city", city},
                {"state", state},
                {"country", "US"},
                {"postal_code", postalCode}
            };

            if(fax != null){
                set.Add("fax", fax);
            }
            if(address2 != null){
                set.Add("address2", address2);
            }
            if(address3 != null){
                set.Add("address3", address3);
            }
        }

        private void ValidatePhone(string phone){
            // remove leading +1. from API and extension
            var stripped = Regex.Replace(phone, @"\+1.|x\d{1,}", "");
            // remove non-numbers from format
            stripped = Regex.Replace(stripped, "[^0-9]", "");
            if(stripped.Length == 10){
                return;
            }
            else{
                Request<bool>.ErrorHandling("Invalid phone number", 13);
            }
        }

        private void ValidateEmail(string email){
            // check for white space and multiple @s followed by alphanumerics@alphanumerics at least 1 . then valid TLD
            if(Regex.IsMatch(email, @"^[^@\s]+@[a-zA-Z\d.-]+\.[a-zA-Z\d.-]{2,63}", RegexOptions.IgnoreCase)){
                return;
            }
            else{
                Request<bool>.ErrorHandling("Invalid email syntax", 13);
            }
        }

        private void ValidateState(string state){
            // private List<string> country = new List<string>{"US", "CA", "AF", "AX", "AL", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "AR", "AM", "AW", "AU", "AT", "AZ", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BQ", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "KH", "CM", "CV", "KY", "CF", "TD", "CL", "CN", "CX", "CC", "CO", "KM", "CG", "CD", "CK", "CR", "CI", "HR", "CU", "CW", "CY", "CZ", "DK", "DJ", "DM", "DO", "EC", "EG", "SV", "GQ", "ER", "EE", "ET", "FK", "FO", "FJ", "FI", "FR", "GF", "PF", "TF", "GA", "GM", "GE", "DE", "GH", "GI", "GR", "GL", "GD", "GP", "GU", "GT", "GG", "GN", "GW", "GY", "HT", "HM", "HN", "HK", "HU", "IS", "IN", "ID", "IR", "IQ", "IE", "IM", "IL", "IT", "JM", "JP", "JE", "JO", "KZ", "KE", "KI", "KP", "KR", "KW", "KG", "LA", "LV", "LB", "LS", "LR", "LY", "LI", "LT", "LU", "MO", "MK", "MG", "MW", "MY", "MV", "ML", "MT", "MH", "MQ", "MR", "MU", "YT", "MX", "FM", "MD", "MC", "MN", "ME", "MS", "MA", "MZ", "MM", "NA", "NR", "NP", "NL", "AN", "NC", "NZ", "NI", "NE", "NG", "NU", "NF", "MP", "NO", "OM", "OT", "PK", "PW", "PS", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "PR", "QA", "RE", "RO", "RU", "RW", "BL", "SH", "KN", "LC", "PM", "VC", "WS", "SM", "ST", "SA", "SN", "RS", "SC", "SL", "SG", "SX", "SK", "SI", "SB", "SO", "ZA", "GS", "SS", "ES", "LK", "SD", "SR", "SJ", "SZ", "SE", "CH", "SY", "TW", "TJ", "TZ", "TH", "TL", "TG", "TK", "TO", "TT", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "AE", "GB", "UK", "UM", "UY", "UZ", "VU", "VA", "VE", "VN", "VG", "VI", "WF", "EH", "YE", "ZR", "ZM", "ZW"};
            List<string> states = new List<string> { "AK", "AL", "AR", "AS", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MP", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UM", "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY" };
            if(states.Contains(state.ToUpper())){
                return;
            }
            else{
                Request<bool>.ErrorHandling("Invalid 'state' entry", 13);
            }
        }

        private void ValidateZip(string postalCode){
            // check for non numbers and length
            if(postalCode.Length == 5 && !Regex.IsMatch(postalCode, "[^0-9]")){
                return;
            }
            else{
                Request<bool>.ErrorHandling("Invalid postal code", 13);
            }
        }

    }
}