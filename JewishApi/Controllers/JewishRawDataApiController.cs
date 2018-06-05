using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using JewishApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JewishApi.Controllers
{
    [RoutePrefix("NewJewish")]
    public class JewishRawDataApiController : ApiController
    {
        [Route("GetNewNews")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonNewsList()
        {
            string username = "", password = "";

            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            //1st Way
            //JObject jsonRequestObject = JObject.Parse(requestResult);
            //username = (string)jsonRequestObject["username"];
            //password = (string)jsonRequestObject["password"];
            //2nd Way
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);
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

                //Read And Write New Data
                string newfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/news.json");
                //string jsonnewdata = JsonConvert.SerializeObject(new { news = NewsList });
                //File.WriteAllText(newfile, jsonnewdata);

                string newJson = File.ReadAllText(newfile);
                var result = JsonConvert.DeserializeObject<RootObject>(newJson);

                //List<NewsModel> News=new List<NewsModel>();

                //foreach (var item in result.News)
                //{
                //    News.Add(new NewsModel(item.NewsId, item.Title, item.Description, item.ImageUrl, item.Url, item.Date));
                //}

                allVersionList = versionlist.versiontype.Where(x => x.filename == "News").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { result.News, VersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetNewServices")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonServiceList()
        {
            string username = "", password = "";
            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                //Check Version List
                int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);
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

                ////Static Service List
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


                ////Fetch Old Data
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
                //        allVersionList.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //        string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //        File.WriteAllText(versionfile, jsonversiondata);
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
                //            allVersionList.Add(new Versiontype(versionnumber.ToString(), "Service"));
                //            string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //            File.WriteAllText(versionfile, jsonversiondata);
                //            allVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                //            return Request.CreateResponse(HttpStatusCode.OK, new { Services = ServiceList, VersionList = allVersionList });
                //        }
                //    }
                //}
                allVersionList = versionlist.versiontype.Where(x => x.filename == "Service").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { Services = result.Service, VersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetNewLocationAndContact")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonLocationAndContactList()
        {
            string username = "", password = "";
            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<Versiontype>();
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/versiontype.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<Example>(version);

                ////Static Location And Contact List
                //List<LocationAndContact> LocationAndContactList = new List<LocationAndContact>
                //{
                //    new LocationAndContact(1, "Jewish Home Family", "10 Link Drive", "Rockleigh", "NJ", "07647", "201-784-1414",
                //        "info@jewishhomefamily.org"),
                //    new LocationAndContact(2, "Jewish Home Assisted Living Kaplen Family Senior Residence", "685 Westwood Avenue", "River Vale", "NJ", "07675", "201-666-2370",
                //        "JHAL@JewishHomeFamily.org"),
                //    new LocationAndContact(3, "Jewish Home at Home", "10 Link Drive", "Rockleigh", "NJ", "07647", "201-784-1414",
                //        "info@jewishhomefamily.org")
                //    /*new LocationAndContact(4, "Ajay", "Vedroad", "Surat", "Gujarat", "395004", "9712995395",
                //        "ajay@gmail.com")*/
                //};

                //Read And Write New Data
                string newfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/LocationAndContact.json");
                //string jsonnewdata = JsonConvert.SerializeObject(new { LocationAndContact = LocationAndContactList });
                //File.WriteAllText(newfile, jsonnewdata);

                string newJson = File.ReadAllText(newfile);
                var result = JsonConvert.DeserializeObject<LocationAndContactList>(newJson);

                allVersionList = versionlist.versiontype.Where(x => x.filename == "LocationAndContact").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { result.LocationAndContact, LocationAndContactVersionList = allVersionList });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("SendNewEcardUser")]
        [HttpPost]
        public async Task<HttpResponseMessage> SendJsonEcardUser()
        {
            string username = "", password = "", ImageId = "", Name = "", Email = "", SendTo = "", RoomNumber = "", Message = "";
            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];
            ImageId = (string)jsonToken["ImageId"];
            Name = (string)jsonToken["Name"];
            Email = (string)jsonToken["Email"];
            SendTo = (string)jsonToken["SendTo"];
            RoomNumber = (string)jsonToken["RoomNumber"];
            Message = (string)jsonToken["Message"];

            if (username == "admin" && password == "admin")
            {
                var allVersionList = new List<EcardUserVersion>();
                //Check Version List
                int versionnumber = 0;
                string versionfile = System.Web.Hosting.HostingEnvironment.MapPath("~/Models/EcardUserVersion.json");
                string version = File.ReadAllText(versionfile);
                var versionlist = JsonConvert.DeserializeObject<EcardUserVersionList>(version);
                List<EcardUserVersion> versions = new List<EcardUserVersion>();
                if (versionlist.EcardUserVersion != null)
                {
                    allVersionList = versionlist.EcardUserVersion.ToList();
                    versionnumber = versionlist.EcardUserVersion.LastOrDefault().UserVersionId;
                    //foreach (var item in locationAndContactVersionList)
                    //{
                    //    versionnumber = int.Parse(item.VersionId);
                    //    versions.Add(new Versiontype(versionnumber.ToString(), "EcardUser"));
                    //}
                }

                //Fetch Old Data
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

                //    versionnumber = versionnumber + 1;
                //    allVersionList.Add(new EcardUserVersion(versionnumber));
                //    string jsonversiondata = JsonConvert.SerializeObject(new { versiontype = allVersionList });
                //    File.WriteAllText(versionfile, jsonversiondata);
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

                //    versionnumber = versionnumber + 1;
                //    allVersionList.Add(new EcardUserVersion(versionnumber));
                //    string jsonversiondata = JsonConvert.SerializeObject(new { EcardUserVersion = allVersionList });
                //    File.WriteAllText(versionfile, jsonversiondata);
                //}

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
                        //File.WriteAllText(file, jsonolddata);
                        objStream.Write(ecardData);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { success = "True", Message = "User Successfully Inserted", eCardUser = EcardUser });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { success = "False", Message = "Invalid Username or password" });
        }

        [Route("GetNewVersionList")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonVersionList()
        {
            string username = "", password = "";
            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];

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

        [Route("GetNewImageList")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetJsonImageList()
        {
            string username = "", password = "";
            //Raw-Data
            string requestResult = await Request.Content.ReadAsStringAsync();
            JToken jsonToken = JObject.Parse(requestResult);
            username = (string)jsonToken["Username"];
            password = (string)jsonToken["Password"];

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


    }
}
