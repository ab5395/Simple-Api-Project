using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class EcardUser
    {
        public int UserId { get; set; }
        public int ImageUrl { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SendTo { get; set; }
        public string RoomNumber { get; set; }
        public string Message { get; set; }


        public EcardUser(int _UserId,int _ImageUrl, string _Name, string _Email, string _SendTo, string _RoomNumber, string _Message)
        {
            UserId = _UserId;
            ImageUrl = _ImageUrl;
            Name = _Name;
            Email = _Email;
            SendTo = _SendTo;
            RoomNumber = _RoomNumber;
            Message = _Message;
        }
    }

    public class EcardUserList
    {
        public List<EcardUser> EcardUser { get; set; }
    }
}

