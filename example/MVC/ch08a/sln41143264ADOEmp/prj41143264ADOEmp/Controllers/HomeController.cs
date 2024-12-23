using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prj41143264ADOEmp.Models;
using System.Data;
using System.Data.SqlClient;

namespace prj41143264ADOEmp.Controllers
{
    public class HomeController : Controller
    { // constr連接字串指定連接dbEmp.mdf資料庫
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
          "AttachDbFilename=|DataDirectory|dbEmp.mdf;" +
          "Integrated Security=True";
        // GET: Home
        public ActionResult Index()
        {
            return View(GetAllEmployee());
        }

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
        //GetEmployees()方法傳回tEmployee員工串列
        private List<tEmployee> GetAllEmployee()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            SqlDataAdapter adp = new SqlDataAdapter
                ("SELECT * FROM tEmployee", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            List<tEmployee> employees = new List<tEmployee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                employees.Add(new tEmployee
                {
                    fEmpId = dt.Rows[i]["fEmpId"].ToString(),
                    fName = dt.Rows[i]["fName"].ToString(),
                    fGender = dt.Rows[i]["fGender"].ToString(),
                    fMail = dt.Rows[i]["fMail"].ToString(),
                    fSalary = int.Parse(dt.Rows[i]["fSalary"].ToString()),
                    fEmploymentDate = DateTime.Parse(dt.Rows[i]["fEmploymentDate"].ToString())
                });
            }
            return employees;
        }
        private tEmployee GetEmployee(string fEmpId)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand
                ("SELECT * FROM tEmployee WHERE fEmpId=@fEmpId", con);
            cmd.Parameters.Add(new SqlParameter
                ("@fEmpId", SqlDbType.NVarChar)).Value = fEmpId;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            tEmployee emp = new tEmployee
            {
                fEmpId = dt.Rows[0]["fEmpId"].ToString(),
                fName = dt.Rows[0]["fName"].ToString(),
                fGender = dt.Rows[0]["fGender"].ToString(),
                fMail = dt.Rows[0]["fMail"].ToString(),
                fSalary = int.Parse(dt.Rows[0]["fSalary"].ToString()),
                fEmploymentDate = DateTime.Parse(dt.Rows[0]["fEmploymentDate"].ToString())
            };
            return emp;
        }

        //executeCmd()方法可執行SqlCommand物件來輯編資料表
        private void ExecuteCmd(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
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
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText =
                        "INSERT INTO tEmployee(fEmpId,fName,fGender,fMail,fSalary,fEmploymentDate)" +
                        "VALUES(@fEmpId,@fName,@fGender,@fMail,@fSalary,@fEmploymentDate)";
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fEmpId", SqlDbType.NVarChar)).Value = employee.fEmpId;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fName", SqlDbType.NVarChar)).Value = employee.fName;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fGender", SqlDbType.NVarChar)).Value = employee.fGender;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fMail", SqlDbType.NVarChar)).Value = employee.fMail;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fSalary", SqlDbType.Int)).Value = employee.fSalary;
                    sqlCommand.Parameters.Add(new SqlParameter
                        ("@fEmploymentDate", SqlDbType.Date)).Value = employee.fEmploymentDate;
                    ExecuteCmd(sqlCommand);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = true;
                    return View(employee);
                }
            }
            return View(employee);
        }

        public ActionResult Edit(string fEmpId)
        {
            return View(GetEmployee(fEmpId));
        }

        [HttpPost]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText =
                    "UPDATE tEmployee SET fName=@fName, fGender=@fGender, fMail=@fMail, " +
                    "fSalary=@fSalary, fEmploymentDate=@fEmploymentDate WHERE fEmpId=@fEmpId";
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fEmpId", SqlDbType.NVarChar)).Value = employee.fEmpId;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fName", SqlDbType.NVarChar)).Value = employee.fName;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fGender", SqlDbType.NVarChar)).Value = employee.fGender;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fMail", SqlDbType.NVarChar)).Value = employee.fMail;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fSalary", SqlDbType.Int)).Value = employee.fSalary;
                sqlCommand.Parameters.Add(new SqlParameter
                    ("@fEmploymentDate", SqlDbType.Date)).Value = employee.fEmploymentDate;
                ExecuteCmd(sqlCommand);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(string fEmpId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM tEmployee WHERE fEmpId=@fEmpId";
            sqlCommand.Parameters.Add(new SqlParameter
                ("@fEmpId", SqlDbType.NVarChar)).Value = fEmpId;
            ExecuteCmd(sqlCommand);
            return RedirectToAction("Index");
        }
    }
}