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
    
    public partial class 產品資料
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 產品資料()
        {
            this.訂貨明細 = new HashSet<訂貨明細>();
        }
    
        public int 產品編號 { get; set; }
        public string 產品 { get; set; }
        public Nullable<int> 供應商編號 { get; set; }
        public Nullable<int> 類別編號 { get; set; }
        public string 單位數量 { get; set; }
        public Nullable<decimal> 單價 { get; set; }
        public Nullable<short> 庫存量 { get; set; }
        public Nullable<short> 已訂購量 { get; set; }
        public Nullable<short> 安全存量 { get; set; }
        public bool 不再銷售 { get; set; }
    
        public virtual 供應商 供應商 { get; set; }
        public virtual 產品類別 產品類別 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<訂貨明細> 訂貨明細 { get; set; }
    }
}
