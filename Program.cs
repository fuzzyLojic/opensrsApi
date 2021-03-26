using System;
using System.Collections.Generic;
using System.Text.Json; 
using System.Net.Http;
using System.Threading.Tasks;
using OpenSRSLib;
using OpenSRSSql;
using System.Data.SqlClient;


namespace opensrsApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiSettings.IsInTestMode = true;
            
            /*** Begin Lookup Availabilty Of Domain ***/
            // LookupRequest req = new LookupRequest("hoobajab.com");
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"status: {res.Status}\nreason: {res.Reason}");
            // Console.WriteLine($"hasclaim: {res.HasClaim}");
            // Console.WriteLine($"email available: {res.EmailAvailable}\nno service: {res.NoService}\nprice status: {res.PriceStatus}");

            /*** ex: run async ***/
            // LookupRequest req = new LookupRequest("hoobajab.com");
            // int i = 0;
            // using (HttpClient client = new HttpClient()){
            //     Task task = req.PostAsync(client);
            //     while(req.Response == null){
            //         i++;
            //     }
            // }
            // Console.WriteLine($"success: {req.Response.Success}\nresponse code: {req.Response.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"status: {req.Response.Status}\nreason: {req.Response.Reason}");
            // Console.WriteLine($"hasclaim: {req.Response.HasClaim}");
            // Console.WriteLine($"email available: {req.Response.EmailAvailable}\nno service: {req.Response.NoService}\nprice status: {req.Response.PriceStatus}");
            // Console.WriteLine($"i: {i}");

            /*** End Lookup Availabilty Of Domain ***/

            /*** Begin Register a New Domain using Default Nameservers ***/
            // string domain = "hoobajab12.com";
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");

            // RegisterNewDefaultRequest req = new RegisterNewDefaultRequest(domain, 1, owner, admin, admin, admin);
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"admin email: {res.AdminEmail}\nasync reason: {res.AyncReason}\nerror: {res.Error}");
            // if(res.CancelledOrders != null){
            //     foreach (var item in res.CancelledOrders)
            //     {
            //         Console.WriteLine($"cancel: {item}");
            //     }
            // }
            // Console.WriteLine($"forced pending: {res.ForcedPending}\nId: {res.Id}\nqueue request id: {res.QueueRequestId}");
            // Console.WriteLine($"registration code: {res.RegistrationCode}\nregistration text: {res.RegistrationText}");
            // Console.WriteLine($"transfer id: {res.TransferId}\nwhois privacy state: {res.WhoisPrivacyState}");
            // /*** End Register a New Domain using Default Nameservers ***/

            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>(){"ns1.stabletransit.com", "ns2.stabletransit.com"};

            // RegisterNewDefaultRequest req = new RegisterNewDefaultRequest("geeblgorp.com", 1, owner, admin, admin, admin, ns);

            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Register a New Domain using Custom Nameservers ***/


            /*** Begin Register a New Domain using Custom Nameservers ***/
            // ContactSet owner = new ContactSet("Joe", "Shmoe", "Captain Shmoe's", "5555555555", "joe@smoe.com", "1234 Count St.", null, null, "Here", "OR", "99999");
            // ContactSet admin = new ContactSet("Dude", "Guy", "IT Dude", "4444444444", "dude@guy.com", "2357 Prime Way", null, null, "There", "OR", "99999");
            // List<string> ns = new List<string>() { "ns1.stabletransit.com", "ns2.stabletransit.com" };

            // RegisterTransferDefaultRequest req = new RegisterTransferDefaultRequest("hoobajab2.com", "5H+q<:4L5~2L", 1, owner, admin, admin, admin, ns);

            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Register a New Domain using Custom Nameservers ***/

            /*** Begin Get DNS records ***/
            // GetDnsRequest req = new GetDnsRequest("hoobajab.com");
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"status: {res.NameserversOk}");
            // if(res.Records != null){
            //     if (res.Records.A != null)
            //     {
            //         foreach (var item in res.Records.A)
            //         {
            //             Console.WriteLine($"A: {item.IpAddress}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.AAAA != null)
            //     {
            //         foreach (var item in res.Records.AAAA)
            //         {
            //             Console.WriteLine($"A: {item.IpAddress}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.CName != null)
            //     {
            //         foreach (var item in res.Records.CName)
            //         {
            //             Console.WriteLine($"CName: {item.HostName}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.MX != null)
            //     {
            //         foreach (var item in res.Records.MX)
            //         {
            //             Console.WriteLine($"MX: {item.HostName}, {item.Priority}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.TXT != null)
            //     {
            //         foreach (var item in res.Records.TXT)
            //         {
            //             Console.WriteLine($"TXT: {item.Text}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.SRV != null)
            //     {
            //         foreach (var item in res.Records.SRV)
            //         {
            //             Console.WriteLine($"SRV: {item.HostName}, {item.Priority}, {item.Weight}, {item.Port}, {item.SubDomain}");
            //         }
            //     }
            // }

            /*** End Get DNS records ***/

            /*** Begin Set DNS records ***/
            // string domain = "hoobajab.com";
            // List<ARecord> aList = new List<ARecord>(){
            //     new ARecord("120.45.6.214"),
            //     new ARecord("111.222.123.213", "ftp")
            // };

            // List<MXRecord> mxList = new List<MXRecord>(){
            //     new MXRecord("mx1.flerb.com", 1),
            //     new MXRecord("mx2.flerb.com", "5", "mail")
            // };

            // List<CNameRecord> cnameList = new List<CNameRecord>(){
            //     new CNameRecord(domain, "www")
            // };

            // List<TXTRecord> txtList = new List<TXTRecord>(){
            //     new TXTRecord("goggle-98q734nv590873459087243v958y24"),
            //     new TXTRecord("gergle-9847cb098743c0918374c509817d3j09187dj90823740978", "geep")
            // };

            // List<SRVRecord> srvList = new List<SRVRecord>(){
            //     new SRVRecord("gribble.org", 1, 10, 4000, "blarp")
            // };

            // DnsZone records = new DnsZone();
            // records.A = aList;
            // records.MX = mxList;
            // records.CName = cnameList;
            // records.TXT = txtList;
            // records.SRV = srvList;

            // SetDnsRequest req = new SetDnsRequest(domain, records);

            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // Console.WriteLine($"status: {res.NameserversOk}");
            // if(res.Records != null){
            //     if (res.Records.A != null)
            //     {
            //         foreach (var item in res.Records.A)
            //         {
            //             Console.WriteLine($"A: {item.IpAddress}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.AAAA != null)
            //     {
            //         foreach (var item in res.Records.AAAA)
            //         {
            //             Console.WriteLine($"A: {item.IpAddress}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.CName != null)
            //     {
            //         foreach (var item in res.Records.CName)
            //         {
            //             Console.WriteLine($"CName: {item.HostName}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.MX != null)
            //     {
            //         foreach (var item in res.Records.MX)
            //         {
            //             Console.WriteLine($"MX: {item.HostName}, {item.Priority}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.TXT != null)
            //     {
            //         foreach (var item in res.Records.TXT)
            //         {
            //             Console.WriteLine($"TXT: {item.Text}, {item.SubDomain}");
            //         }
            //     }
            //     if (res.Records.SRV != null)
            //     {
            //         foreach (var item in res.Records.SRV)
            //         {
            //             Console.WriteLine($"SRV: {item.HostName}, {item.Priority}, {item.Weight}, {item.Port}, {item.SubDomain}");
            //         }
            //     }
            // }
            /*** Begin Set DNS records ***/

            /*** Begin Set DNS MX record***/
            // List<MXRecord> mxList = new List<MXRecord>(){
            //     new MXRecord("mx4.moop.com", 5, "www"),
            //     new MXRecord("mx5.moop.com", 10)
            // };
            // SetDnsRequest req = new SetDnsRequest("hoobajab.com", null, null, null, mxList, null, null);
            // Console.WriteLine(req.XML);
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** Begin Set DNS MX record ***/

            /*** Begin Get All Info ***/
            // GetAllInfoRequest req = new GetAllInfoRequest("hoobajab.com");
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            // if(res.Success){
            //     Console.WriteLine($"AutoRenew: {res.AutoRenew}\nRegistryCreateDate: {res.RegistryCreateDate}");
            //     Console.WriteLine($"RegistryExpireDate: {res.RegistryExpireDate}\nRegistryUpdateDate: {res.RegistryUpdateDate}");
            //     Console.WriteLine($"AffiliateId: {res.AffiliateId}\nSponsoringRsp: {res.SponsoringRsp}");
            //     Console.WriteLine($"ExpireDate: {res.ExpireDate}\nLetExpire: {res.LetExpire}");
            //     foreach (var item in res.ContactSet)
            //     {
            //         Console.WriteLine($"contact: {item.Key}");
            //         Console.WriteLine($"first name: {item.Value.FirstName}");
            //     }
            //     foreach (var item in res.NameserverList)
            //     {
            //         Console.WriteLine($"ns: {item.Name}");
            //     }
            // }

            /*** End Get All Info ***/

            /*** Begin Get Transfer Code ***/
            // AuthCodeRequest req = new AuthCodeRequest("hoobajab7.com");
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Get Transfer Code ***/

            /*** Begin Unlock Domain ***/
            // UnlockRequest req = new UnlockRequest("hoobajab7.com");
            // var res = req.Post();
            // Console.WriteLine($"success: {res.Success}\nresponse code: {res.ResponseCode}\nresponse text: {req.Response.ResponseText}");
            /*** End Unlock Domain ***/


        }   
    }
}
