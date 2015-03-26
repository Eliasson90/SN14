using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQL_Labb4.Models
{
    public class LanaBok
    {
        public int LanId { get; set; }
        public int BokId { get; set; }
        public int KundId { get; set; }
        public int KopiaId { get; set; }
        public string Titel { get; set; }
    }
}