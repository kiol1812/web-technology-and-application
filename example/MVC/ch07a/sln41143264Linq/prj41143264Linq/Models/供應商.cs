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
    
    public partial class 供應商
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 供應商()
        {
            this.產品資料 = new HashSet<產品資料>();
        }
    
        public int 供應商編號 { get; set; }
        public string 供應商1 { get; set; }
        public string 連絡人 { get; set; }
        public string 連絡人職稱 { get; set; }
        public string 地址 { get; set; }
        public string 城市 { get; set; }
        public string 行政區 { get; set; }
        public string 郵遞區號 { get; set; }
        public string 國家地區 { get; set; }
        public string 電話 { get; set; }
        public string 傳真電話 { get; set; }
        public string 首頁 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<產品資料> 產品資料 { get; set; }
    }
}
