using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class Report
    {
        public string Jour { get; set; }
        public double Absences { get; set; }
        public double Retards { get; set; }
    }
}