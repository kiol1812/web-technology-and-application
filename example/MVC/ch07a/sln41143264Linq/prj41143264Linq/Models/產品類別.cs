//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj41143264Linq.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 產品類別
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 產品類別()
        {
            this.產品資料 = new HashSet<產品資料>();
        }
    
        public int 類別編號 { get; set; }
        public string 類別名稱 { get; set; }
        public string 說明 { get; set; }
        public byte[] 圖片 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<產品資料> 產品資料 { get; set; }
    }
}
