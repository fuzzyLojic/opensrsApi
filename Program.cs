using System;
using System.Threading.Tasks;       // needed for Task object for PostAsync
using System.Collections.Generic;
using OpenSRSLib;                   // needed to change encoding for StringWriter from utf-16

namespace opensrsApi
{
    class Program
    {
        static void Main(string[] args)
        {

            /*** Begin Lookup Availabilty Of Domain ***/
            // Lookup req = new Lookup("hoobajab.com");
            // Task<Dictionary<string, string>> task = req.Post();
            // foreach (var item in task.Result)
            // {
            //     Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            // }
            /*** End Lookup Availabilty Of Domain ***/


            /*** Begin Register a New Domain using Default Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");

            // RegisterNewDefault req = new RegisterNewDefault("hoobajab1.com", 1, owner, admin, admin, admin);
            // Task<Dictionary<string, string>> task = req.Post();
            // foreach (var item in task.Result)
            // {
            //     Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            // }
            /*** End Register a New Domain using Default Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>(){"ns1.stabletransit.com", "ns2.stabletransit.com"};

            // RegisterNewDefault req = new RegisterNewDefault("hoobajab1.com", 1, owner, admin, admin, admin, ns);

            // Task<Dictionary<string, string>> task = req.Post();
            // foreach (var item in task.Result)
            // {
            //     Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            // }
            /*** End Register a New Domain using Custom Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>() { "ns1.stabletransit.com", "ns2.stabletransit.com" };

            // RegisterTransferDefault req = new RegisterTransferDefault("hoobajab2.com", "5H+q<:4L5~2L", 1, owner, admin, admin, admin, ns);

            // Task<Dictionary<string, string>> task = req.Post();
            // foreach (var item in task.Result)
            // {
            //     Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            // }
            /*** End Register a New Domain using Custom Nameservers ***/

            /*** Begin Set DNS A record***/
            // List<ARecord> aList = new List<ARecord>(){
            //     new ARecord("123.45.6.214")
            // };
            // SetDns req = new SetDns("hoobajab.com", aList, null, null, null, null, null);

            // Console.WriteLine(req.XML);
            // Task<Dictionary<string, string>> task = req.Post();
            // foreach (var item in task.Result)
            // {
            //     Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            // }
            /*** Begin Set DNS A record ***/

            /*** Begin Set DNS MX record***/
            List<MXRecord> mxList = new List<MXRecord>(){
                new MXRecord("mx1.moop.com", 5, "www"),
                new MXRecord("mx2.moop.com", 10, "www")
            };
            SetDns req = new SetDns("hoobajab.com", null, null, null, mxList, null, null);

            Task<Dictionary<string, string>> task = req.Post();
            foreach (var item in task.Result)
            {
                Console.WriteLine("key: " + item.Key + "  value: " + item.Value);
            }
            /*** Begin Set DNS MX record ***/
        }   
    }
}
