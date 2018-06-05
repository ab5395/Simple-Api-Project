using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }

        public ImageModel(int _ImageId,string _ImageUrl)
        {
            ImageId = _ImageId;
            ImageUrl = _ImageUrl;
        }
    }
}