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
    public class XiaZhuInfoController : Controller
    {
        DAL.XiazhuinfoDAL dal;
        DAL.UserinfoDAL udal;
        BLL.ICaiPiaoBLL cpbll;
        public XiaZhuInfoController(DAL.XiazhuinfoDAL dal, BLL.BJPK10 pk10bll,DAL.UserinfoDAL udal)
        {
            this.udal = udal;
            this.dal = dal;
            this.cpbll = pk10bll;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string start, string end, string cabh)
        {

            string cond = "1=1";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                cond += $" and username like '%{key}%'";
            }
            if (!string.IsNullOrEmpty(start))
            {
                DateTime d;
                if (DateTime.TryParse(start, out d))
                {
                    cond += $" and createtime>='{d.ToString("yyyy-MM-dd HH:mm:ss")}'";
                }
            }
            if (!string.IsNullOrEmpty(end))
            {
                DateTime d;
                if (DateTime.TryParse(end, out d))
                {
                    cond += $" and createtime<='{d.ToString("yyyy-MM-dd HH:mm:ss")}'";
                }
            }
            /*     if (!string.IsNullOrEmpty(cabh))
             {
                 cabh = Tool.GetSafeSQL(cabh);
                 cond += $" and cabh='{cabh}'";
             }*/
            return cond;
        }

        /// <summary>
        /// 取总记录数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTotalCount(string key, string start, string end, string cabh)
        {
            int totalcount = dal.CalcCount(GetCond(key, start, end, cabh));
            return Content(totalcount.ToString());
        }

        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult List(int pageindex, int pagesize, string key, string start, string end, string cabh)
        {
            List<Model.Xiazhuinfo> list = dal.GetListArray("*", "id desc", pagesize, pageindex, GetCond(key, start, end, cabh));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                arr.Add(new
                {
                    id = item.id,
                    createtime = item.createtime.ToString("yyyy-MM-dd HH:mm:ss"),
                    userid = item.userid,
                    username = item.username,
                    czid = item.czid,
                    czname = item.czname,
                    wfid = item.wfid,
                    wfname = item.wfname,
                    buycode = item.buycode,
                    beishu = item.beishu,
                    buymoney = item.buymoney,
                    remark = item.remark,
                    qihao = item.qihao,
                    iszj = item.iszj,
                    zjmoney = item.zjmoney,
                    kjcode = item.kjcode + "",
                    shouxufee = item.shouxufee,
                    czr = item.czr,
                    kjtime = string.IsNullOrEmpty(item.kjcode) ? "" : item.kjtime.ToString("yyyy-MM-dd HH:mm:ss"),

                });
            }
            return Json(arr);
        }

        public ActionResult Add(int? id)
        {
            ViewBag.userlist = udal.GetListArray("1=1 order by username");
            Model.CaiPiao current_cp = cpbll.GetCurrentModel();
            if (current_cp==null)
            {
                return Content("当前期号不存在，请联系管理员添加！");
            }
            return View(current_cp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string buycode,string qihao,string userid)
        {
            try
            {
                double buymoney = 2;
                int beishu = 1;
                int czid = 23; //北京PK10
                int wfid = 20000101; //猜冠军
                string str = dal.XiaZhu(userid, buycode, buymoney, beishu, qihao, true, wfid, czid);
                return Json(new { code=0,msg = str});
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }

        public ActionResult Delete(string ids)
        {
            try
            {
                int success = 0;
                string[] ss = ids.Split(',');
                foreach (var item in ss)
                {
                    int x;
                    if (int.TryParse(item, out x))
                    {
                        dal.Delete(x);
                        success++;
                    }
                }
                return Json(new { code = 0, msg = "成功删除" + success + "条记录！" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }

        //兑奖
        public ActionResult DuiJiang(int id)
        {
            try
            {
                Model.Xiazhuinfo xz = dal.GetModel(id);
                if (xz == null)
                {
                    return Json(new { code = 1, msg = "没有该下注单信息" });
                }
                if (xz.iszj != 0)
                {
                    return Json(new { code = 1, msg = "该下注单已兑奖过" });
                }
                string str = cpbll.DuiJiang(xz.id);
                return Json(new { code = 0, msg = str });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = "出错：" + ex.Message });
            }
        }
    }
}
