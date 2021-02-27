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
            // Lookup req = new Lookup("domain.com");
            // Task.Run((Func<Task>)(() => req.Post()));
            // Console.Read();
            /*** End Lookup Availabilty Of Domain ***/


            /*** Begin Register a New Domain using Default Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");

            // RegisterNewDefault newreg = new RegisterNewDefault("hoobajab1.com", 1, owner, admin, admin, admin);
            // Task.Run((Func<Task>)(() => newreg.Post()));
            // Console.Read();
            /*** End Register a New Domain using Default Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>(){"ns1.stabletransit.com", "ns2.stabletransit.com"};

            // RegisterNewDefault newreg = new RegisterNewDefault("hoobajab1.com", 1, owner, admin, admin, admin, ns);
            
            // Task.Run((Func<Task>)(() => newreg.Post()));
            // Console.Read();
            /*** End Register a New Domain using Custom Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            List<string> ns = new List<string>() { "ns1.stabletransit.com", "ns2.stabletransit.com" };

            RegisterTransferDefault newtransfer = new RegisterTransferDefault("hoobajab2.com", "5H+q<:4L5~2L", 1, owner, admin, admin, admin, ns);
            
            Task.Run((Func<Task>)(() => newtransfer.Post()));
            Console.Read();
            /*** End Register a New Domain using Custom Nameservers ***/
        }   
    }
}
