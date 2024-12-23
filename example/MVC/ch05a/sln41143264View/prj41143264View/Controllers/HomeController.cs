using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prj41143264View.Models;

namespace prj41143264View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<NightMarket> nightMarkets = new List<NightMarket>();
            nightMarkets.Add(new NightMarket { Id = "A01", Name = "逢甲夜市", Address = "407台中市西屯區文華路" });
            nightMarkets.Add(new NightMarket { Id = "A02", Name = "一中街商圈", Address = "404台中市北區一中街" });
            nightMarkets.Add(new NightMarket { Id = "A03", Name = "中華路夜市", Address = "400台中市中區公園路" });
            nightMarkets.Add(new NightMarket { Id = "A04", Name = "忠孝路夜市", Address = "402台中市南區忠孝路" });
            nightMarkets.Add(new NightMarket { Id = "A05", Name = "豐原廟東夜市", Address = "420台中市豐原區中正路167巷" });
            nightMarkets.Add(new NightMarket { Id = "A06", Name = "東海夜市", Address = "433台中市龍井區新興路" });
            return View(nightMarkets);
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
    }
}