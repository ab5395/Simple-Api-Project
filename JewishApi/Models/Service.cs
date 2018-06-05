using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class Service
    {
        public int ServicesId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Service(int _ServicesId, string _Image, string _Title, string _Description, string _Url)
        {
            ServicesId = _ServicesId;
            Image = _Image;
            Title = _Title;
            Description = _Description;
            Url = _Url;
        }
    }

    public class ServiceList
    {
        public List<Service> Service { get; set; }
    }
}