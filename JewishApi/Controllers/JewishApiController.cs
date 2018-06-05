using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Management;
using JewishApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace JewishApi.Controllers
{
    [RoutePrefix("Jewish")]
    public class JewishApiController : ApiController
    {
        [Route("GetNews")]
        [HttpPost]
        //public HttpResponseMessage GetNewsList(IEnumerable<NewsModel> JsonNewsList)
        //public HttpResponseMessage GetJsonNewsList(string username, string password)
        public async Task<HttpResponseMessage> GetJsonNewsList()
        {
            //For FileUpload in POstman
            //string root = HttpContext.Current.Server.MapPath("~/App_Data");
            //var provider = new MultipartFormDataStreamProvider(root);
            //if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            //{
            //    foreach (string file in System.Web.HttpContext.Current.Request.Files)
            //    {
            //        byte[] postedFile = null;
            //        using (var binaryReader = new BinaryReader(System.Web.HttpContext.Current.Request.Files[file].InputStream))
            //        {
            //            postedFile = binaryReader.ReadBytes(System.Web.HttpContext.Current.Request.Files[file].ContentLength);

            //        }
            //        string fileName = System.Web.HttpContext.Current.Request.Files.AllKeys[0];
            //    }
            //}
            //await Request.Content.ReadAsMultipartAsync(provider);

            //Header Request
            //var requestHeader = Request.Headers;
            //string username = requestHeader.GetValues("UserName").First();
            //string password = requestHeader.GetValues("Password").First();
            //Header Request


            string username = "", password = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                }
            }

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                ////Check Version List
                //int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);
                //List<Versiontype> versions = new List<Versiontype>();
                //if (versionlist.versiontype != null)
                //{
                //    var newsVersionList = versionlist.versiontype.Where(x => x.filename == "News").ToList();
                //    allVersionList = versionlist.versiontype.Where(x => x.filename != "News").ToList();
                //    foreach (var item in newsVersionList)
                //    {
                //        versionnumber = int.Parse(item.VersionId);
                //        versions.Add(new Versiontype(versionnumber.ToString(), "News"));
                //    }
                //}

                //Static NEws List
                //string newsDescription = @"Grab top news stories, news headlines from India & around the world. ... Man detained by ATS for IS ties told to reappear for questioning today1 sec ago.";
                //List<NewsModel> NewsList = new List<NewsModel>
                //{
                //    new NewsModel(1, "news1", newsDescription + newsDescription,
                //        "/Images/News/88274743.jpg", "https://www.google.co.in",
                //        "14-03-2014"),
                //    new NewsModel(2, "news2", newsDescription,
                //        "/Images/News/Door3316.jpg", "https://www.google.co.in",
                //        "15-03-2014"),
                //    new NewsModel(3, "news3", newsDescription,
                //        "/Images/News/DSCN0525.jpg", "https://www.google.co.in",
                //        "24-05-2014"),
                //    new NewsModel(4, "News4 With Update", newsDescription + newsDescription,
                //        "/Images/News/iStock_000007439065Large.jpg",
                //        "https://www.google.co.in", "24-04-2014"),
                //    new NewsModel(4, "New News5", "This is new description",
                //        "/Images/News/iStock_000007439065Large.jpg",
                //        "https://www.google.co.in", "04-05-2014"),
                //    new NewsModel(4, "New News6", "This is new updated description",
                //        "/Images/News/iStock_000010352774Large.jpg",
                //        "https://www.google.co.in", "02-05-2014")
                //};


                //Fetch Old Data
                //string oldfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/oldnews.json");
                //string oldJson = File.ReadAllText(oldfile);
                //var oldresult = JsonConvert.DeserializeObject<RootObject>(oldJson);


                //Read And Write New Data
                string newfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/news.json");
                //string jsonnewdata = JsonConvert.SerializeObject(new { news = NewsList });
                //File.WriteAllText(newfile, jsonnewdata);

                string newJson = File.ReadAllText(newfile);
                var result = JsonConvert.DeserializeObject<RootObject>(newJson);


                //Check data
                //List<NewsModel> checklist = oldresult.news;
                //foreach (var item in result.news)
                //{
                //    if (checklist == null)
                //    {
                //        string jsonolddata = JsonConvert.SerializeObject(new { news = result.news });
                //        File.WriteAllText(oldfile, jsonolddata);

                //        versionnumber = versionnumber + 1;
                //        //versions.Add(new Versiontype(versionnumber.ToString(), "News"));
                //        //foreach (var data in versions)
                //        //{
                //        //    allVersionList.Add(new Versiontype(data.VersionId, "News"));
                //        //}
                //        allVersionList.Add(new Versiontype(versionnumber.ToString(), "News"));

                //        string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //        File.WriteAllText(versionfile, jsonversiondata);
                //        allVersionList = versionlist.versiontype.Where(x => x.filename == "News").ToList();
                //        return Request.CreateResponse(HttpStatusCode.OK, new { News = NewsList, NewsVersionList = allVersionList });
                //        //break;
                //    }
                //    else
                //    {
                //        var obj = checklist.FirstOrDefault(x => x.NewsId == item.NewsId && x.Title == item.Title && x.Description == item.Description && x.ImageUrl == item.ImageUrl && x.Url == item.Url && x.Date == item.Date);
                //        if (obj == null)
                //        {
                //            string jsonolddata = JsonConvert.SerializeObject(new { news = result.news });
                //            File.WriteAllText(oldfile, jsonolddata);

                //            versionnumber = versionnumber + 1;
                //            //versions.Add(new Versiontype(versionnumber.ToString(), "News"));
                //            //foreach (var data in versions)
                //            //{
                //            //    allVersionList.Add(new Versiontype(data.VersionId, "News"));
                //            //}
                //            allVersionList.Add(new Versiontype(versionnumber.ToString(), "News"));
                //            string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //            File.WriteAllText(versionfile, jsonversiondata);
                //            allVersionList = versionlist.versiontype.Where(x => x.filename == "News").ToList();
                //            return Request.CreateResponse(HttpStatusCode.OK, new { News = NewsList, NewsVersionList = allVersionList });
                //            //break;
                //        }
                //    }
                //}
                allVersionList = versionlist.versiontype.Where(x => x.filename == "News").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { result.News, VersionList = allVersionList });
                //return Request.CreateResponse(HttpStatusCode.OK, new { NewsVersionList = versions });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetServices")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonServiceList()
        {
            string username = "", password = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                }
            }

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                ////Check Version List
                //int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);
                ////List<Versiontype> myDeserializedObjList = (List<Versiontype>)JsonConvert.DeserializeObject(version, typeof(List<Versiontype>));
                //List<Versiontype> versions = new List<Versiontype>();
                //if (versionlist.versiontype != null)
                //{
                //    var serviceVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                //    allVersionList = versionlist.versiontype.Where(x => x.filename != "Service").ToList();
                //    foreach (var item in serviceVersionList)
                //    {
                //        versionnumber = int.Parse(item.VersionId);
                //        versions.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //    }
                //}

                ////Static NEws List
                //List<Service> ServiceList = new List<Service>
                //{
                //    new Service(1, "/Images/Services/23.jpg", "Service1",
                //        "Service definition is key to service management. ... A well-defined service also identifies internal processes necessary to provide and support the service.",
                //        "https://www.google.co.in"),
                //    new Service(2, "/Images/Services/Golf2011RE3203.jpg", "Service2",
                //        "At a minimum, every customer-facing service should have a high-level service definition as described below.",
                //        "https://www.google.co.in"),
                //    new Service(3, "/Images/Services/JHAL2950.jpg", "Service3",
                //        "A Service Description plays an important role in enabling access to a service. Most service description languages are designed for machine consumption",
                //        "https://www.google.co.in"),
                //    new Service(4, "/Images/Services/JHAL3010.jpg", "Service4 Update",
                //        "Service definition is key to service management.", "https://www.google.co.in")
                //};


                //Fetch Old Data
                //string oldfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/oldService.json");
                //string oldJson = File.ReadAllText(oldfile);
                //var oldresult = JsonConvert.DeserializeObject<ServiceList>(oldJson);


                //Read And Write New Data
                string newfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/Service.json");
                //string jsonnewdata = JsonConvert.SerializeObject(new { Service = ServiceList });
                //File.WriteAllText(newfile, jsonnewdata);

                string newJson = File.ReadAllText(newfile);
                var result = JsonConvert.DeserializeObject<ServiceList>(newJson);

                //Check data
                //List<Service> checklist = oldresult.Service;
                //foreach (var item in result.Service)
                //{
                //    if (checklist == null)
                //    {
                //        string jsonolddata = JsonConvert.SerializeObject(new { Service = result.Service });
                //        File.WriteAllText(oldfile, jsonolddata);

                //        versionnumber = versionnumber + 1;
                //        //versions.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //        //foreach (var data in versions)
                //        //{
                //        //    allVersionList.Add(new Versiontype(data.VersionId, "Service"));
                //        //}
                //        allVersionList.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //        string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //        //File.WriteAllText(versionfile, jsonversiondata);
                //        allVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                //        return Request.CreateResponse(HttpStatusCode.OK, new { Services = ServiceList, VersionList = allVersionList });
                //        //break;
                //    }
                //    else
                //    {
                //        var obj = checklist.FirstOrDefault(x => x.ServicesId == item.ServicesId && x.Image == item.Image && x.Title == item.Title && x.Description == item.Description && x.Url == item.Url);
                //        if (obj == null)
                //        {
                //            string jsonolddata = JsonConvert.SerializeObject(new { Service = result.Service });
                //            File.WriteAllText(oldfile, jsonolddata);

                //            versionnumber = versionnumber + 1;
                //            //versions.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //            //foreach (var data in versions)
                //            //{
                //            //    allVersionList.Add(new Versiontype(data.VersionId, "Service"));
                //            //}
                //            allVersionList.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //            string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //            File.WriteAllText(versionfile, jsonversiondata);
                //            allVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                //            return Request.CreateResponse(HttpStatusCode.OK, new { Services = ServiceList, VersionList = allVersionList });
                //            //break;
                //        }
                //    }
                //}
                allVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { Services = result.Service, VersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetLocationAndContact")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonLocationAndContactList()
        {
            string username = "", password = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                if (key.Equals("Username"))
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        username = val;
                    }
                }
                if (key.Equals("Password"))
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        password = val;
                    }
                }
            }
            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                ////Check Version List
                //int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);
                ////List<Versiontype> myDeserializedObjList = (List<Versiontype>)JsonConvert.DeserializeObject(version, typeof(List<Versiontype>));
                //List<Versiontype> versions = new List<Versiontype>();
                //if (versionlist.versiontype != null)
                //{
                //    var locationAndContactVersionList = versionlist.versiontype.Where(x => x.filename == "LocationAndContact").ToList();
                //    allVersionList = versionlist.versiontype.Where(x => x.filename != "LocationAndContact").ToList();
                //    foreach (var item in locationAndContactVersionList)
                //    {
                //        versionnumber = int.Parse(item.VersionId);
                //        versions.Add(new Versiontype(versionnumber.ToString(), "LocationAndContact"));
                //    }
                //}

                ////Static NEws List
                //List<LocationAndContact> LocationAndContactList = new List<LocationAndContact>
                //{
                //    new LocationAndContact(1, "Jewish Home Family", "10 Link Drive", "Rockleigh", "NJ", "07647", "201-784-1414",
                //        "info@jewishhomefamily.org"),
                //    new LocationAndContact(2, "Jewish Home Assisted Living Kaplen Family Senior Residence", "685 Westwood Avenue", "River Vale", "NJ", "07675", "201-666-2370",
                //        "JHAL@JewishHomeFamily.org"),
                //    new LocationAndContact(3, "Jewish Home at Home", "10 Link Drive", "Rockleigh", "NJ", "07647", "201-784-1414",
                //        "info@jewishhomefamily.org")
                //};


                ////Fetch Old Data
                //string oldfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/oldLocationAndContact.json");
                //string oldJson = File.ReadAllText(oldfile);
                //var oldresult = JsonConvert.DeserializeObject<LocationAndContactList>(oldJson);


                //Read And Write New Data
                string newfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/LocationAndContact.json");
                //string jsonnewdata = JsonConvert.SerializeObject(new { LocationAndContact = LocationAndContactList });
                //File.WriteAllText(newfile, jsonnewdata);

                string newJson = File.ReadAllText(newfile);
                var result = JsonConvert.DeserializeObject<LocationAndContactList>(newJson);

                ////Check data
                //List<LocationAndContact> checklist = oldresult.LocationAndContact;
                //foreach (var item in result.LocationAndContact)
                //{
                //    if (checklist == null)
                //    {
                //        string jsonolddata = JsonConvert.SerializeObject(new { LocationAndContact = result.LocationAndContact });
                //        File.WriteAllText(oldfile, jsonolddata);

                //        versionnumber = versionnumber + 1;
                //        //versions.Add(new Versiontype(versionnumber.ToString(), "LocationAndContact"));
                //        //foreach (var data in versions)
                //        //{
                //        //    allVersionList.Add(new Versiontype(data.VersionId, "LocationAndContact"));
                //        //}
                //        allVersionList.Add(new Versiontype(versionnumber.ToString(), "LocationAndContact"));
                //        string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //        File.WriteAllText(versionfile, jsonversiondata);
                //        allVersionList = versionlist.versiontype.Where(x => x.filename == "LocationAndContact").ToList();
                //        return Request.CreateResponse(HttpStatusCode.OK, new { LocationAndContact = LocationAndContactList, VersionList = allVersionList });
                //        //break;
                //    }
                //    else
                //    {
                //        var obj = checklist.FirstOrDefault(x => x.LocationId == item.LocationId && x.LocationName == item.LocationName && x.Address == item.Address && x.City == item.City && x.State == item.State && x.Zip == item.Zip && x.Phone == item.Phone && x.Email == item.Email);
                //        if (obj == null)
                //        {
                //            string jsonolddata = JsonConvert.SerializeObject(new { LocationAndContact = result.LocationAndContact });
                //            File.WriteAllText(oldfile, jsonolddata);

                //            versionnumber = versionnumber + 1;
                //            //versions.Add(new Versiontype(versionnumber.ToString(), "LocationAndContact"));
                //            //foreach (var data in versions)
                //            //{
                //            //    allVersionList.Add(new Versiontype(data.VersionId, "LocationAndContact"));
                //            //}
                //            allVersionList.Add(new Versiontype(versionnumber.ToString(), "LocationAndContact"));
                //            string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //            File.WriteAllText(versionfile, jsonversiondata);
                //            allVersionList = versionlist.versiontype.Where(x => x.filename == "LocationAndContact").ToList();
                //            return Request.CreateResponse(HttpStatusCode.OK, new { LocationAndContact = LocationAndContactList, VersionList = allVersionList });
                //            //break;
                //        }
                //    }
                //}
                allVersionList = versionlist.versiontype.Where(x => x.filename == "LocationAndContact").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { result.LocationAndContact, LocationAndContactVersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("SendEcardUser")]
        [HttpPost]
        //public HttpResponseMessage SendJsonEcardUser(string username, string password, string ImageId, string Name, string Email, string SendTo, string RoomNumber, string Message)
        public async Task<HttpResponseMessage> SendJsonEcardUser()
        {
            string username = "", password = "", ImageId = "", Name = "", Email = "", SendTo = "", RoomNumber = "", Message = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                    case "ImageId":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            ImageId = val;
                        }
                        break;
                    case "Name":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            Name = val;
                        }
                        break;
                    case "Email":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            Email = val;
                        }
                        break;
                    case "SendTo":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            SendTo = val;
                        }
                        break;
                    case "RoomNumber":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            RoomNumber = val;
                        }
                        break;
                    case "Message":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            Message = val;
                        }
                        break;

                }
            }

            if (username == "admin" && password == "admin")
            {
                //var allVersionList = new List<Versiontype>();
                ////Check Version List
                //int versionnumber = 0;
                //string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                //string version = File.ReadAllText(versionfile);
                //var versionlist = JsonConvert.DeserializeObject<Example>(version);
                ////List<Versiontype> myDeserializedObjList = (List<Versiontype>)JsonConvert.DeserializeObject(version, typeof(List<Versiontype>));
                //List<Versiontype> versions = new List<Versiontype>();
                //if (versionlist.versiontype != null)
                //{
                //    var locationAndContactVersionList = versionlist.versiontype.Where(x => x.filename == "EcardUser").ToList();
                //    allVersionList = versionlist.versiontype.Where(x => x.filename != "EcardUser").ToList();
                //    foreach (var item in locationAndContactVersionList)
                //    {
                //        versionnumber = int.Parse(item.VersionId);
                //        versions.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                //    }
                //}

                ////Fetch Old Data
                //string oldfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/EcardUser.json");
                //string oldJson = File.ReadAllText(oldfile);
                //var oldresult = JsonConvert.DeserializeObject<EcardUserList>(oldJson);

                //List<EcardUser> ecardUserList = new List<EcardUser>();


                //if (oldresult.EcardUser == null)
                //{
                //    List<EcardUser> FirstEcardUserList = new List<EcardUser>
                //    {
                //        new EcardUser(1, int.Parse(ImageId), Name, Email, SendTo, RoomNumber, Message)
                //    };
                //    string jsonolddata = JsonConvert.SerializeObject(new { EcardUser = FirstEcardUserList });
                //    File.WriteAllText(oldfile, jsonolddata);

                //    //versionnumber = versionnumber + 1;
                //    //versions.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                //    //foreach (var data in versions)
                //    //{
                //    //    allVersionList.Add(new Versiontype(data.VersionId, "EcardUser"));
                //    //}
                //    //allVersionList.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                //    //string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //    //File.WriteAllText(versionfile, jsonversiondata);
                //    return Request.CreateResponse(HttpStatusCode.OK, new { success = "True", Message = "User Successfully Inserted", eCardUserList = FirstEcardUserList });
                //}
                //else
                //{
                //    ecardUserList.Clear();
                //    int uid = oldresult.EcardUser.Last().UserId + 1;

                //    ecardUserList = oldresult.EcardUser;

                //    ecardUserList.Add(new EcardUser(uid, int.Parse(ImageId), Name, Email, SendTo, RoomNumber, Message));

                //    string jsonolddata = JsonConvert.SerializeObject(new { EcardUser = ecardUserList });
                //    File.WriteAllText(oldfile, jsonolddata);

                //    //versionnumber = versionnumber + 1;
                //    ////versions.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                //    ////foreach (var data in versions)
                //    ////{
                //    ////    allVersionList.Add(new Versiontype(data.VersionId, "EcardUser"));
                //    ////}
                //    //allVersionList.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                //    //string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //    //File.WriteAllText(versionfile, jsonversiondata);

                var allVersionList = new List<EcardUserVersion>();
                int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/EcardUserVersion.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<EcardUserVersionList>(version);
                List<EcardUserVersion> versions = new List<EcardUserVersion>();
                if (versionlist.EcardUserVersion != null)
                {
                    allVersionList = versionlist.EcardUserVersion.ToList();
                    versionnumber = versionlist.EcardUserVersion.LastOrDefault().UserVersionId;
                }
                versionnumber = versionnumber + 1;
                allVersionList.Add(new EcardUserVersion(versionnumber));
                string jsonversiondata = JsonConvert.SerializeObject(new { EcardUserVersion = allVersionList });
                File.WriteAllText(versionfile, jsonversiondata);
                string filename = "EcardUser_" + versionnumber + ".json";
                string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/EcardUser/");
                string file = filePath + filename;
                List<EcardUser> EcardUser = new List<EcardUser>();
                if (!File.Exists(file))
                {
                    using (StreamWriter objStream = new StreamWriter(file, true))
                    {
                        EcardUser.Add(new EcardUser(versionnumber, int.Parse(ImageId), Name, Email, SendTo, RoomNumber,
                        Message));
                        string ecardData = JsonConvert.SerializeObject(new { EcardUser = EcardUser });
                        objStream.Write(ecardData);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = "True", Message = "User Successfully Inserted", eCardUser = EcardUser });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetVersionList")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonVersionList()
        {
            string username = "", password = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                }
            }

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                //Check Version List
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);

                allVersionList = versionlist.versiontype.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { VersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetImageList")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonImageList()
        {
            string username = "", password = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                }
            }

            if (username == "admin" && password == "admin")
            {
                List<ImageModel> ImageList = new List<ImageModel>
                {
                    new ImageModel(1, "/Images/Ecards/ecard-1-lg.jpg"),
                    new ImageModel(2, "/Images/Ecards/ecard-2-lg.jpg"),
                    new ImageModel(3, "/Images/Ecards/ecard-3-lg.jpg"),
                    new ImageModel(4, "/Images/Ecards/ecard-4-lg.jpg"),
                    new ImageModel(5, "/Images/Ecards/ecard-5-lg.jpg"),
                    new ImageModel(6, "/Images/Ecards/ecard-6-lg.jpg"),
                    new ImageModel(7, "/Images/Ecards/ecard-7-lg.jpg"),
                    new ImageModel(8, "/Images/Ecards/ecard-8-lg.jpg"),
                    new ImageModel(9, "/Images/Ecards/ecard-9-lg.jpg"),
                    new ImageModel(10, "/Images/Ecards/ecard-10-lg.jpg"),
                    new ImageModel(11, "/Images/Ecards/ecard-11-lg.jpg"),
                    new ImageModel(12, "/Images/Ecards/ecard-12-lg.jpg")
                };

                return Request.CreateResponse(HttpStatusCode.OK, new { ImageList = ImageList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("UpdateversionList")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateVersionList()
        {
            string username = "", password = "", news = "", locationAndContact = "", service = "";
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            // Show all the key-value pairs.
            foreach (var key in provider.FormData.AllKeys)
            {
                switch (key)
                {
                    case "Username":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            username = val;
                        }
                        break;
                    case "Password":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            password = val;
                        }
                        break;
                    case "News":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            news = val;
                        }
                        break;
                    case "LocationAndContact":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            locationAndContact = val;
                        }
                        break;
                    case "Service":
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            service = val;
                        }
                        break;
                }
            }
            if (username == "admin" && password == "admin")
            {
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                var allVersionList = new List<Versiontype>
                {
                    new Versiontype(news, "News"),
                    new Versiontype(locationAndContact, "LocationAndContact"),
                    new Versiontype(service, "Service")
                };
                //Check Version List
                string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                File.WriteAllText(versionfile, jsonversiondata);
                return Request.CreateResponse(HttpStatusCode.OK, new { VersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

    }
}
