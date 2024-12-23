﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prj41143264Linq.Models;

namespace prj41143264Linq.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }
        // 查詢所有員工記錄
        public string ShowEmployee()
        {
            NorthwindEntities db = new NorthwindEntities();
            //Linq擴充方法寫法
            var result = db.員工;
            //var result = from m in db.員工
            //             select m;
            string show = "";
            foreach (var m in result)
            {
                show += $"編號：{m.員工編號}<br />";
                show += $"姓名：{m.姓名 + m.稱呼}<br />";
                show += $"職稱：{m.職稱}<hr>";
            }
            return show;
        }
        //找出客戶地址中含有keyword關鍵字的客戶記錄
        public string ShowCustomerByAddress(string keyword)
        {
            NorthwindEntities db = new NorthwindEntities();
            //Linq擴充方法寫法
            var result = db.客戶.Where(m => m.地址.Contains(keyword));
            //Linq查詢運算式寫法
            //var result = from m in db.客戶
            //             where m.地址.Contains(keyword)
            //             select m;
            string show = "";
            foreach (var m in result)
            {
                show += $"公司：{m.公司名稱}<br />";
                show += $"姓名：{m.連絡人}{m.連絡人職稱}<br />";
                show += $"地址：{m.地址}<hr>";
            }
            return show;
        }

        // 查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序
        public string ShowProduct()
        {
            NorthwindEntities db = new NorthwindEntities();
            //Linq擴充方法寫法
            var result = db.產品資料
                .Where(m => m.單價 > 30)
                .OrderBy(m => m.單價)
                .ThenByDescending(m => m.庫存量);
            //Linq查詢運算式寫法
            //var result = from m in db.產品資料
            //             where m.單價 > 30
            //             orderby m.單價 ascending, m.庫存量 descending
            //             select m;
            string show = "";
            foreach (var m in result)
            {
                show += $"產品：{m.產品}<br />";
                show += $"單價：{m.單價}<br />";
                show += $"庫存：{m.庫存量}<hr>";
            }
            return show;
        }
        //查詢產品平均價、總和、筆數，最高價和最低價資訊
        public string ShowProductInfo()
        {
            NorthwindEntities db = new NorthwindEntities();
            //Linq擴充方法寫法
            var result = db.產品資料;
            //Linq查詢運算式寫法
            //var result = from m in db.產品資料
            //             select m;
            string show = "";
            show += $"單價平均：{result.Average(m => m.單價)}<br />";
            show += $"單價總和：{result.Sum(m => m.單價)}<br />";
            show += $"記錄筆數：{result.Count()}<br />";
            show += $"單價最高：{result.Max(m => m.單價)}<br />";
            show += $"單價最低：{result.Min(m => m.單價)}";
            return show;
        }
    }
}