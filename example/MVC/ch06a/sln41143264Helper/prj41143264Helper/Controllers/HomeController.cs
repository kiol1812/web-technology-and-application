using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prj41143264Helper.Models;

namespace prj41143264Helper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = "E01", Name = "王小明", Salary = 42000 });
            employees.Add(new Employee { Id = "E02", Name = "李小華", Salary = 60000 });
            employees.Add(new Employee { Id = "E03", Name = "蔡小龍", Salary = 22000 });
            employees.Add(new Employee { Id = "E04", Name = "周小旬", Salary = 34000 });
            employees.Add(new Employee { Id = "E05", Name = "張小五", Salary = 52000 });
            return View(employees);
        }
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            string msg = "";
            msg = $"註冊資料如下：<br>" +
               $"帳號：{member.UserId}<br>" +
               $"密碼：{member.Pwd}<br>" +
               $"姓名：{member.Name}<br>" +
               $"信箱：{member.Email}<br>" +
               $"生日：{member.BirthDay.ToShortDateString()}";
            ViewBag.Msg = msg;
            return View(member);
        }
    }
}