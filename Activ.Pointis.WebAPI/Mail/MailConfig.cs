using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Mail
{
    public class MailConfig
    {
        public string gLogin { get; set; }
        public string gFrom { get; set; }
        public string gsmtp { get; set; }
        public Int16 gport { get; set; }
        public string gPwd { get; set; }
        public bool gssl { get; set; }
    }
}