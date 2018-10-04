using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.CaiPiao.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class KaiJiangInfoController : Controller
    {
        DAL.QihaoinfoDAL qhdal;
        public KaiJiangInfoController(DAL.QihaoinfoDAL qhdal) {
            this.qhdal = qhdal;
        }

        public ActionResult Add(int id) {
            Model.Qihaoinfo qh = qhdal.GetModel(id);
            if (qh==null)
            {
                return Content("qh is null");
            }
            return View(qh);
        }

        [HttpPost]
        public ActionResult Add(int id, string kjcode) {
            try
            {
                qhdal.UpdateByCond($"kjcode='{kjcode}'",$"id={id}");
                return Json(new { code=0,msg="成功"});
            }
            catch (Exception ex)
            {
                return Json(new { code=1,msg="出错："+ex.Message});
            }
        }
    }
}
