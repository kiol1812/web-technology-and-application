using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;

namespace prj41143264ADO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        // GET: Home/ShowEmployee，查詢所有員工記錄
        public String ShowEmployee()
        {
            SqlConnection con = new SqlConnection();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
              "AttachDbFilename=|DataDirectory|Northwind.mdf;" +
              "Integrated Security=True";
            con.ConnectionString = constr;
            string sql = "SELECT 員工編號, 姓名, 稱呼, 職稱 FROM 員工";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            string str = "";
            //寫法一
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += $"編號：{dt.Rows[i]["員工編號"] }<br />";
                str += $"姓名：{dt.Rows[i]["姓名"]}{dt.Rows[i]["稱呼"]}<br />";
                str += $"職稱：{dt.Rows[i]["職稱"]}<hr>";
            }
            //寫法二
            //foreach (DataRow row in dt.Rows)
            //{
            //    str += $"編號：{row["員工編號"]}<br />";
            //    str += $"姓名：{row["姓名"]}{row["稱呼"] }<br />";
            //    str += $"職稱：{row["職稱"]}<hr>";
            //}
            return str;
        }

        // 查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序        
        // GET: Home/ShowProduct
        public string ShowProduct()
        {
            SqlConnection con = new SqlConnection();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
              "AttachDbFilename=|DataDirectory|Northwind.mdf;" +
              "Integrated Security=True";
            con.ConnectionString = constr;
            string sql = "SELECT 產品,單價,庫存量 FROM 產品資料 " +
              "WHERE 單價>30 ORDER BY 單價 ASC, 庫存量 DESC";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            string str = "";
            //寫法一
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += $"產品：{dt.Rows[i]["產品"] }<br />";
                str += $"單價：{dt.Rows[i]["單價"] }<br />";
                str += $"庫存：{dt.Rows[i]["庫存量"] }<hr>";
            }
            //寫法二
            //foreach (DataRow row in dt.Rows)
            //{
            //    str += $"產品：{row["產品"] }<br />";
            //    str += $"單價：{row["單價"] }<br />";
            //    str += $"庫存：{row["庫存量"]}<hr>";
            //}
            return str;
        }

        //找出客戶地址中含有keyword關鍵字的客戶記錄
        // GET: Home/ShowCustomerByAddress?keyword=中山路
        public string ShowCustomerByAddress(string keyword)
        {
            SqlConnection con = new SqlConnection();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
              "AttachDbFilename=|DataDirectory|Northwind.mdf;" +
              "Integrated Security=True";
            con.ConnectionString = constr;
            string sql = "SELECT 公司名稱, 連絡人, 連絡人職稱, 地址 FROM 客戶" +
              " WHERE 地址 LIKE N'%" + keyword.Replace("'", "''") + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            string str = "";
            //寫法一
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += $"公司：{dt.Rows[i]["公司名稱"] }<br />";
                str += $"姓名：{dt.Rows[i]["連絡人"]}{dt.Rows[i]["連絡人職稱"] }<br />";
                str += $"地址：{dt.Rows[i]["地址"] }<hr>";
            }
            //寫法二
            //foreach (DataRow row in dt.Rows)
            //{
            //    str += $"公司：{row["公司名稱"]}<br />";
            //    str += $"姓名：{row["連絡人"]}{ row["連絡人職稱"] }<br />";
            //    str += $"地址：{row["地址"]}<hr>";
            //}
            return str;
        }

    }
}