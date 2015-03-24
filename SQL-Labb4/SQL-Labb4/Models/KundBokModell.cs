using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQL_Labb4.Models
{
    public class KundBokModell
    {
        public int BokId { get; set; }
        public string Titel { get; set; }
        public DateTime LaneDatum { get; set; }
        public DateTime? LamnasTillbaka { get; set; }
    }
}