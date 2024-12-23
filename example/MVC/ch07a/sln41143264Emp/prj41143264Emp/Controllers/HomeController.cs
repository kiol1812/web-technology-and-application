using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prj41143264Emp.Models;

namespace prj41143264Emp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        dbEmpEntities db = new dbEmpEntities();
        // GET: Home
        public ActionResult Index()
        {
            var employees = db.tEmployee.ToList();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.tEmployee.Where(m => m.fEmpId == employee.fEmpId)
                    .FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(employee);
                }
                db.tEmployee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(string fEmpId)
        {
            var employee = db.tEmployee
                .Where(m => m.fEmpId == fEmpId).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                var temp = db.tEmployee
                    .Where(m => m.fEmpId == employee.fEmpId)
                    .FirstOrDefault();
                temp.fName = employee.fName;
                temp.fSalary = employee.fSalary;
                temp.fMail = employee.fMail;
                temp.fGender = employee.fGender;
                temp.fEmploymentDate = employee.fEmploymentDate;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(string fEmpId)
        {
            var employee = db.tEmployee
                .Where(m => m.fEmpId == fEmpId).FirstOrDefault();
            db.tEmployee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}