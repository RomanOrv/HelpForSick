using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpForSick.WebUI.Frontend.Models
{
    public class PersonInfoModel
    {
       public string MainInfo { get; set; }
        public string Diagnosis { get; set; }
        public string MoneyInfo { get; set; }
        public HttpPostedFileBase Images { get; set; }
    }
}