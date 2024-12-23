using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj41143264Helper.Models
{
    public class Member
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}