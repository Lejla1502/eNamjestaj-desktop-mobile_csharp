//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eProdajaNamjestaja_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UlaziStavke
    {
        public int UlaziStavkeID { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodID { get; set; }
        public int UlazID { get; set; }
    
        public virtual Ulazi Ulazi { get; set; }
        public virtual Proizvodi Proizvodi { get; set; }
    }
}
