//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KumasStokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_KumasTipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_KumasTipi()
        {
            this.KumasOzellikleri = new HashSet<KumasOzellikleri>();
        }
    
        public int ID { get; set; }
        public string KumasAdi { get; set; }
        public Nullable<int> TipID { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KumasOzellikleri> KumasOzellikleri { get; set; }
        public virtual Tip Tip { get; set; }
    }
}