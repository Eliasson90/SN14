//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bibliotek
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lan
    {
        public int LanId { get; set; }
        public Nullable<int> kundId { get; set; }
        public Nullable<int> KopiaId { get; set; }
        public System.DateTime LaneDatum { get; set; }
        public System.DateTime LamnasTillbaka { get; set; }
        public Nullable<int> SparradKund { get; set; }
    
        public virtual Kopia Kopia { get; set; }
        public virtual Kund Kund { get; set; }
    }
}