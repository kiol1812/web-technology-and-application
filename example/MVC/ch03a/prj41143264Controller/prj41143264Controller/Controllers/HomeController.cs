using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prj41143264Controller.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //計算陣列總合
        public string ShowAry()
        {
            int[] score = new int[] { 78, 89, 30, 100, 66 };
            string show = "";
            int sum = 0;
            foreach (var m in score)
            {
                show += m + ",";
                sum += m;
            }
            show += "<br />";
            show += "總合：" + sum;
            return show;
        }

        //傳回顯示1.jpg~8.jpg的HTML字串
        // name字串陣列存放8張圖的名稱
        string[] name = new string[] { "大甲鎮瀾宮", "竹田車站",
                 "西螺大橋","萬金天主堂", "萬巒豬腳街",  "潮州戲曲故事館",
                 "貓鼻頭", "頭城搶孤" };
        //傳回顯示name字串陣列八張圖檔的HTML字串
        public string ShowImages()
        {
            string show = "<h2>旅遊相簿</h2>";
            for (int i = 0; i < name.Length; i++)
            {
                show += $"<img src='../images/{name[i]}.jpg' width='150'>　";
            }
            return show;
        }

        //依index參數取得陣列對應索引的圖示
        public string ShowImageByIndex(int index)
        {
            string show = $"<h3>index參數必須介於0~{name.GetUpperBound(0)}</h3>";
            if (index >= 0 && index <= name.GetUpperBound(0))
            {
                show = $"<p align='center'>" +
                    $"<img src='../images/{name[index]}.jpg' width='350'>" +
                    $"<br>{name[index]}</p>";
            }
            return show;
        }
    }
}