using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Util;
using Niunan.CaiPiao.Web.Models;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class NewsController : Controller
    {
        DAL.NewsDAL ndal;
        public NewsController(DAL.NewsDAL ndal) {
            this.ndal = ndal;
        }
        public IActionResult OnePage(string cabh) {
            Model.News n = ndal.GetModelByCabh(cabh);
            if (n==null)
            {
                return Content("无此新闻");
            }
            return View(n);
        }
    }
}
