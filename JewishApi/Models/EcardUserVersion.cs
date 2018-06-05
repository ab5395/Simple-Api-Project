using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewishApi.Models
{
    public class EcardUserVersion
    {
        public int UserVersionId { get; set; }

        public EcardUserVersion(int _userVersionId)
        {
            UserVersionId = _userVersionId;
        }
    }

    public class EcardUserVersionList
    {
        public List<EcardUserVersion> EcardUserVersion { get; set; }
    }
}