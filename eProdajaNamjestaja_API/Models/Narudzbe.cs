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
    
    public partial class Narudzbe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Narudzbe()
        {
            this.Izlazi = new HashSet<Izlazi>();
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
        }
    
        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public System.DateTime Datum { get; set; }
        public bool Statuss { get; set; }
        public bool Otkazano { get; set; }
        public int KupacID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izlazi> Izlazi { get; set; }
        public virtual Kupci Kupci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}
