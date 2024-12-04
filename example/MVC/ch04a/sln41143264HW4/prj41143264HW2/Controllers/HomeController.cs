using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prj41143264HW2.Models;

namespace prj41143264HW2.Controllers
{
    public class HomeController : Controller
    {
        DB41143264Entities db = new DB41143264Entities();
        // GET: Home
        /*public ActionResult Index()
        {
            var accounts = db.a41143264User.OrderByDescending(m => m.fDate).ToList();
            return View(accounts);
        }*/

        bool is_login = false;

        public RedirectResult Index()
        {
            return Redirect("~/Home/Lobby");
        }

        public ActionResult Lobby()
        {
            return View();
        }

        public ActionResult LoginProcess(string Account)
        {
            var account = db.a41143264User.Where(m => m.fAccount == Account).FirstOrDefault();
            return View(account);
        }

        [HttpPost]
        public ActionResult LoginProcess(int fId, string fAccount, string fPassword, string fEmail, DateTime fDate)
        {
            var account = db.a41143264User.Where(m => m.fId == fId).FirstOrDefault();
            if(account.fAccount == fAccount&&account.fPassword == fPassword) return RedirectToAction("Index");
            return RedirectToAction("Login");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fAccount, string fPassword, string fEmail, DateTime fDate)
        {
            a41143264User account = new a41143264User();
            account.fAccount = fAccount;
            account.fPassword = fPassword;
            account.fEmail = fEmail;
            account.fDate = fDate;
            db.a41143264User.Add(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var account = db.a41143264User.Where(m => m.fId == id).FirstOrDefault();
            db.a41143264User.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var account = db.a41143264User.Where(m => m.fId == id).FirstOrDefault();
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(int fId, string fAccount, string fPassword, string fEmail, DateTime fDate)
        {
            var account = db.a41143264User.Where(m => m.fId == fId).FirstOrDefault();
            account.fAccount = fAccount;
            account.fPassword = fPassword;
            account.fEmail = fEmail;
            account.fDate = fDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}