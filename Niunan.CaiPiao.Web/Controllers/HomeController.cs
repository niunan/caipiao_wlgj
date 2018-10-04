using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Web.Models;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 计算倒计时
        /// </summary>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public ActionResult CalcDJS(DateTime endtime)
        {
            TimeSpan ts = endtime - DateTime.Now;
            int hh = ts.Hours;
            int mm = ts.Minutes;
            int ss = ts.Seconds;
            return Json(new { success = true, hh = hh.ToString("d2"), mm = mm.ToString("d2"), ss = ss.ToString("d2") });
        }
    }
}
