using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;
using OpenSRSLib;                   // needed to change encoding for StringWriter from utf-16
using System.Net.Http;
using System.Threading.Tasks;

namespace opensrsApi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Request.isInTestMode = true;

            /*** Begin Lookup Availabilty Of Domain ***/
            // LookupRequest req = new LookupRequest("hoobajab.com");
            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");


            /*** ex: run async ***/
            // Task task = req.PostAsync();
            // int i = 0;
            // while(req.Response == null){
            //     i++;
            // }
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"i: {i}");

            /*** ex: parse to XML ***/
            // XDocument xDoc = req.Response.ToXDoc;
            // Console.WriteLine("\n\nXML:");
            // foreach (var item in xDoc.Descendants("item"))
            // {
            //     Console.WriteLine($"key: {item.Attribute("key").Value}  value: {item.Value}");
            // }

            /*** ex: parse to JSON ***/
            // string json = req.Response.ToJson;
            // Console.WriteLine(json);
            // JsonDocument jsonDoc = JsonDocument.Parse(json);
            // Console.WriteLine($"\n\nJson:\nis_success: {jsonDoc.RootElement.GetProperty("is_success").GetString()}");

            /*** End Lookup Availabilty Of Domain ***/


            /*** Begin Register a New Domain using Default Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");

            // RegisterNewDefaultRequest req = new RegisterNewDefaultRequest("hoobajab7.com", 1, owner, admin, admin, admin);
            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // /*** End Register a New Domain using Default Nameservers ***/

            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>(){"ns1.stabletransit.com", "ns2.stabletransit.com"};

            // RegisterNewDefaultRequest req = new RegisterNewDefaultRequest("geeblgorp.com", 1, owner, admin, admin, admin, ns);

            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Register a New Domain using Custom Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>() { "ns1.stabletransit.com", "ns2.stabletransit.com" };

            // RegisterTransferDefaultRequest req = new RegisterTransferDefaultRequest("hoobajab2.com", "5H+q<:4L5~2L", 1, owner, admin, admin, admin, ns);

            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Register a New Domain using Custom Nameservers ***/

            /*** Begin Get DNS records ***/
            // GetDnsRequest req = new GetDnsRequest("hoobajab.com");
            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis valid: {req.IsValid}\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Get DNS records ***/

            /*** Begin Set DNS A record***/
            // List<ARecord> aList = new List<ARecord>(){
            //     new ARecord("123.45.6.214")
            // };
            // SetDnsRequest req = new SetDnsRequest("hoobajab5.com", aList, null, null, null, null, null);

            // Console.WriteLine(req.XML);
            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine(req.Response.ToJson());
            /*** Begin Set DNS A record ***/

            /*** Begin Set DNS MX record***/
            // List<MXRecord> mxList = new List<MXRecord>(){
            //     new MXRecord("mx4.moop.com", 5, "www"),
            //     new MXRecord("mx5.moop.com", 10, "www")
            // };
            // SetDnsRequest req = new SetDnsRequest("hoobajab2.com", null, null, null, mxList, null, null);

            // req.Post();
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** Begin Set DNS MX record ***/

            /*** Begin Get All Info ***/
            // GetAllInfoRequest req = new GetAllInfoRequest("hoobajab.com");
            // req.Post();
            // Console.WriteLine($"isValid: {req.IsValid}");
            // Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");

            // string json = req.Response.ToJson;
            // Console.WriteLine(json);
            /*** End Get All Info ***/

            /*** Begin Get Transfer Code ***/
            AuthCodeRequest req = new AuthCodeRequest("hoobajab7.com");
            req.Post();
            Console.WriteLine($"response string:\n{req.Response.ToString}\n\nis success: {req.Response.IsSuccess}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Get Transfer Code ***/


            /*** Begin JSON Test ***/
            //             string json = @"<?xml version='1.0' encoding='UTF-8' standalone='no' ?>
            // <!DOCTYPE OPS_envelope SYSTEM 'ops.dtd'>
            // <OPS_envelope>
            //  <header>
            //   <version>0.9</version>
            //   </header>
            //  <body>
            //   <data_block>
            //    <dt_assoc>
            //     <item key='protocol'>XCP</item>
            //     <item key='object'>DOMAIN</item>
            //     <item key='action'>SW_REGISTER</item>
            //     <item key='attributes'>
            //      <dt_assoc>
            //       <item key='f_parkp'>Y</item>
            //       <item key='affiliate_id'></item>
            //       <item key='auto_renew'></item>
            //       <item key='comments'>Sample comment</item>
            //       <item key='domain'>example2rwetw42tt4t.com</item>
            //       <item key='reg_type'>new</item>
            //       <item key='reg_username'>daniel</item>
            //       <item key='reg_password'>adf3wyt444fvfc3</item>
            //       <item key='f_whois_privacy'>1</item>
            //       <item key='period'>1</item>
            //       <item key='link_domains'>0</item>
            //       <item key='custom_nameservers'>1</item>
            //       <item key='f_lock_domain'>1</item>
            //       <item key='reg_domain'></item>
            //       <item key='contact_set'>
            //        <dt_assoc>
            //         <item key='admin'>
            //          <dt_assoc>
            //           <item key='country'>US</item>
            //           <item key='address3'>Admin</item>
            //           <item key='org_name'>Example Inc.</item>
            //           <item key='phone'>+1.4165550123x1812</item>
            //           <item key='state'>CA</item>
            //           <item key='address2'>Suite 100</item>
            //           <item key='last_name'>Adams</item>
            //           <item key='email'>adams@example.com</item>
            //           <item key='city'>Santa Clara</item>
            //           <item key='postal_code'>90210</item>
            //           <item key='fax'>+1.4165550125</item>
            //           <item key='address1'>32 Oak Street</item>
            //           <item key='first_name'>Adler</item>
            //          </dt_assoc>
            //         </item>
            //         <item key='owner'>
            //          <dt_assoc>
            //           <item key='country'>US</item>
            //           <item key='address3'>Owner</item>
            //           <item key='org_name'>Example Inc.</item>
            //           <item key='phone'>+1.4165550123x1902</item>
            //           <item key='state'>CA</item>
            //           <item key='address2'>Suite 500</item>
            //           <item key='last_name'>Ottway</item>
            //           <item key='email'>ottway@example.com</item>
            //           <item key='city'>SomeCity</item>
            //           <item key='postal_code'>90210</item>
            //           <item key='fax'>+1.4165550124</item>
            //           <item key='address1'>32 Oak Street</item>
            //           <item key='first_name'>Owen</item>
            //          </dt_assoc>
            //         </item>
            //         <item key='billing'>
            //          <dt_assoc>
            //           <item key='country'>US</item>
            //           <item key='address3'>Billing</item>
            //           <item key='org_name'>Example Inc.</item>
            //           <item key='phone'>+1.4165550123x1248</item>
            //           <item key='state'>CA</item>
            //           <item key='address2'>Suite 200</item>
            //           <item key='last_name'>Burton</item>
            //           <item key='email'>burton@example.com</item>
            //           <item key='city'>Santa Clara</item>
            //           <item key='postal_code'>90210</item>
            //           <item key='fax'>+1.4165550136</item>
            //           <item key='address1'>32 Oak Street</item>
            //           <item key='first_name'>Bill</item>
            //          </dt_assoc>
            //         </item>
            //        </dt_assoc>
            //       </item>
            //       <item key='nameserver_list'>
            //        <dt_array>
            //         <item key='0'>
            //          <dt_assoc>
            //           <item key='name'>ns1.systemdns.com</item>
            //           <item key='sortorder'>1</item>
            //          </dt_assoc>
            //         </item>
            //         <item key='1'>
            //          <dt_assoc>
            //           <item key='name'>ns2.systemdns.com</item>
            //           <item key='sortorder'>2</item>
            //          </dt_assoc>
            //         </item>
            //        </dt_array>
            //       </item>
            //       <item key='encoding_type'></item>
            //       <item key='custom_tech_contact'>0</item>
            //      </dt_assoc>
            //     </item>
            //     <item key='registrant_ip'>10.0.10.19</item>
            //    </dt_assoc>
            //   </data_block>
            //  </body>
            // </OPS_envelope>";
            //             json = XmlDoc.ToJson(json);
            //             Console.WriteLine(json);
            //             JsonDocument jsonDoc = JsonDocument.Parse(json);
            //             Console.WriteLine($"\n\nJson:\nadmin address1: {jsonDoc.RootElement[0].GetProperty("attributes").GetProperty("contact_set").GetProperty("admin").GetProperty("address1").GetString()}");

            /*** End JSON Test ***/
        }   
    }
}
