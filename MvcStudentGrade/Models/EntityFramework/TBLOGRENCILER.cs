//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStudentGrade.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLOGRENCILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOGRENCILER()
        {
            this.TBLNOTLAR = new HashSet<TBLNOTLAR>();
        }
    
        public int OGID { get; set; }
        public string OGRADI { get; set; }
        public string OGRSOYAD { get; set; }
        public string OGRFOTO { get; set; }
        public string OGRCINSIYET { get; set; }
        public Nullable<int> OGRKULUP { get; set; }
    
        public virtual TBLKULUPLER TBLKULUPLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNOTLAR> TBLNOTLAR { get; set; }
    }
}
