using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQL_Labb4.Models
{
    public class TaBortKundModell
    {
        public int KundId { get; set; }
        public string ForNamn { get; set; }
        public string EfterNamn { get; set; }
        public bool HarLan { get; set; }
    }
}