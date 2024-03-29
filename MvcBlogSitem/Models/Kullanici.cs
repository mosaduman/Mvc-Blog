//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcBlogSitem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.KullaniciRols = new HashSet<KullaniciRol>();
            this.Makales = new HashSet<Makale>();
            this.Kullanici1 = new HashSet<Kullanici>();
            this.Kullanicis = new HashSet<Kullanici>();
        }
    
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Parola { get; set; }
        public string EmailAdres { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public System.DateTime KayitTarihi { get; set; }
        public Nullable<int> ResimID { get; set; }
        public Nullable<bool> Yazar { get; set; }
        public Nullable<bool> Onaylandi { get; set; }
        public Nullable<bool> Aktif { get; set; }
    
        public virtual Resim Resim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciRol> KullaniciRols { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makale> Makales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanicis { get; set; }
    }
}
