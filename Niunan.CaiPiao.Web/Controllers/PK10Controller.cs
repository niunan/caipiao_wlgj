using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class PK10Controller : Controller
    {
        DAL.QihaoinfoDAL qhdal;
        BLL.ICaiPiaoBLL cpbll;
        public PK10Controller(BLL.BJPK10 pk10bll, DAL.QihaoinfoDAL qhdal)
        {
            this.cpbll = pk10bll;
            this.qhdal = qhdal;
        }
        public IActionResult Index()
        {
            Model.CaiPiao current = cpbll.GetCurrentModel();
            ViewBag.current = current; //本期
            ViewBag.prev = cpbll.GetModel((int.Parse(current.qihao) - 1).ToString());
            return View();
        }

        //根据期号取开奖号
        public ActionResult GetKjCode(string qihao)
        {

            string tmp = qhdal.GetOneFiled("kjcode", $"czid=23 and qihao='{qihao}'");
            if (string.IsNullOrEmpty(tmp))
            {
                return Json(new { success = false, ball1 = "-", ball2 = "-", ball3 = "-", ball4 = "-", ball5 = "-" });
            }
            else
            {
                string[] ss = tmp.Split(',');
                return Json(new
                {
                    success = true,
                    ball1 = ss[0],
                    ball2 = ss[1],
                    ball3 = ss[2],
                    ball4 = ss[3],
                    ball5 = ss[4],
                    ball6 = ss[5],
                    ball7 = ss[6],
                    ball8 = ss[7],
                    ball9 = ss[8],
                    ball10 = ss[9]
                });
            }
        }

        //取当前期和上一期
        public ActionResult GetCurrentAndPrev()
        {
            Model.CaiPiao current = cpbll.GetCurrentModel();
            Model.CaiPiao prev = cpbll.GetModel((int.Parse(current.qihao) - 1).ToString());
            return Json(new
            {
                current_qihao = current.qihao,
                current_endtime = current.endtime.ToString("yyyy-MM-dd HH:mm:ss"),
                prev_qihao = prev.qihao,
            });
        }
    }
}