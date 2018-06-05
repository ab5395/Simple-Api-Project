using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class LocationAndContact
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public LocationAndContact(int _LocationId, string _LocationName, string _Address, string _City, string _State, string _Zip, string _Phone, string _Email)
        {
            LocationId = _LocationId;
            LocationName = _LocationName;
            Address = _Address;
            City = _City;
            State = _State;
            Zip = _Zip;
            Phone = _Phone;
            Email = _Email;
        }
    }

    public class LocationAndContactList
    {
        public List<LocationAndContact> LocationAndContact { get; set; }
    }

}