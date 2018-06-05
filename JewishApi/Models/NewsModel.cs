using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }


        public NewsModel(int _NewsId, string _Title, string _Description, string _ImageUrl, string _Url, string _Date)
        {
            NewsId = _NewsId;
            Title = _Title;
            Description = _Description;
            ImageUrl = _ImageUrl;
            Url = _Url;
            Date = _Date;
        }
    }

    public class Versiontype
    {
        public string VersionId { get; set; }
        public string filename { get; set; }
        public Versiontype(string _VersionId,string _filename)
        {
            VersionId = _VersionId;
            filename = _filename;
        }
    }

    public class Example
    {
        public IList<Versiontype> versiontype { get; set; }
    }

    public class RootObject
    {
        public List<NewsModel> News { get; set; }
    }



}