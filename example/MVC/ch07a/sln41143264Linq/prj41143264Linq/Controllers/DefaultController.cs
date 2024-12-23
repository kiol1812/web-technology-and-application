using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prj41143264Linq.Models;

namespace prj41143264Linq.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public string ShowArrayDesc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = "";
            //Linq擴充方法寫法
            var result = score.OrderByDescending(m => m);
            //Linq查詢運算式寫法
            //var result = from m in score
            //             orderby m descending
            //             select m;
            show = "遞減排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "總和：" + result.Sum();
            return show;
        }
        public string ShowArrayAsc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = "";
            //Linq擴充方法寫法
            var result = score.OrderBy(m => m);
            //Linq查詢運算式寫法
            //var result = from m in score
            //             orderby m ascending
            //             select m;
            show = "遞增排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "平均：" + result.Average();
            return show;
        }
        //查詢members會員串列的帳號與密碼
        public string LoginMember(string uid, string pwd)
        {
            //members串列放入三筆會員資料
            List<Member> members = new List<Member>();
            members.Add(new Member { UserId = "tom", Pwd = "123", Name = "湯姆" });
            members.Add(new Member { UserId = "jasper", Pwd = "456", Name = "賈思伯" });
            members.Add(new Member { UserId = "mary", Pwd = "789", Name = "瑪麗" });
            //Linq擴充方法寫法
            var result = members
                .Where(m => m.UserId == uid && m.Pwd == pwd)
                .FirstOrDefault();
            //Linq查詢運算式寫法
            //var result = (from m in members
            //             where m.UserId==uid && m.Pwd==pwd
            //             select m).FirstOrDefault();
            string show = "";
            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
            }
            else
            {
                show = "帳號密碼錯誤！";
            }
            return show;
        }
    }
}