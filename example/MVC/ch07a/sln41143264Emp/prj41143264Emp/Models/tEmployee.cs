//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace prj41143264Emp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tEmployee
    {
        [DisplayName("員工編號")]
        [Required(ErrorMessage = "員工編號不可空白")]
        [StringLength(7, ErrorMessage = "員工編號必須是4~7個字元", MinimumLength = 4)]
        public string fEmpId { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string fName { get; set; }

        [DisplayName("性別")]
        public string fGender { get; set; }

        [DisplayName("信箱")]
        [EmailAddress(ErrorMessage = "E-Mail格式有誤")]
        public string fMail { get; set; }

        [DisplayName("薪資")]
        [Range(23000, 65000, ErrorMessage = "薪資必須介於23000~65000")]
        public Nullable<int> fSalary { get; set; }

        [DisplayName("雇用日期")]
        [DataType(DataType.Date, ErrorMessage = "雇用日期必須為日期格式")]
        public Nullable<System.DateTime> fEmploymentDate { get; set; }
    }
}
