//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SteamDBCopyCatMVC.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class TabelToko
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TabelToko()
        {
            this.TabelHargas = new HashSet<TabelHarga>();
        }
    
        public int ID_Toko { get; set; }
        public string Nama_Toko { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabelHarga> TabelHargas { get; set; }
    }
}