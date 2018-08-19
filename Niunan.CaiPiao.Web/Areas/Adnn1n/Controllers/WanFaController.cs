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
using Niunan.CaiPiao.DAL;
using Niunan.CaiPiao.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.CaiPiao.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class WanFaController : BaseController
    {
        DAL.WanfaDAL dal  ;
        DAL.CaizhongDAL czdal  ;

        public WanFaController(UserinfoDAL udal,DAL.WanfaDAL dal, DAL.CaizhongDAL czdal) : base(udal)
        {
            this.dal = dal;
            this.czdal = czdal;
        }

        public ActionResult Index()
        {
            string str = "";
            List<Model.Wanfa> list = dal.GetDistinct("groupname");
            foreach (var item in list)
            {
                str += $"<option value='{item.groupname}'>{item.groupname}</option>";
            }
            ViewBag.seloption = str;

            string str2 = "";
            List<Model.Wanfa> list2 = dal.GetDistinct("bigname");
            foreach (var item in list2)
            {
                str2 += $"<option value='{item.bigname}'>{item.bigname}</option>";
            }
            ViewBag.seloption_bigname = str2;
            return View();
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string start, string end, string cabh, string bigname)
        {

            string cond = "1=1";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                cond += $" and wfname like '%{key}%'";
            }
            /*  if (!string.IsNullOrEmpty(start))
             {
                 DateTime d;
                 if (DateTime.TryParse(start, out d))
                 {
                     cond += $" and createdate>='{d.ToString("yyyy-MM-dd HH:mm:ss")}'";
                 }
             }
             if (!string.IsNullOrEmpty(end))
             {
                 DateTime d;
                 if (DateTime.TryParse(end, out d))
                 {
                     cond += $" and createdate<='{d.ToString("yyyy-MM-dd HH:mm:ss")}'";
                 }
             }*/
            if (!string.IsNullOrEmpty(bigname))
            {
                bigname = Tool.GetSafeSQL(bigname);
                cond += $" and bigname='{bigname}'";
            }
            if (!string.IsNullOrEmpty(cabh))
            {
                cabh = Tool.GetSafeSQL(cabh);
                cond += $" and groupname='{cabh}'";
            }
            return cond;
        }

        /// <summary>
        /// 取总记录数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTotalCount(string key, string start, string end, string cabh, string bigname)
        {
            int totalcount = dal.CalcCount(GetCond(key, start, end, cabh, bigname));
            return Content(totalcount.ToString());
        }

        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult List(int pageindex, int pagesize, string key, string start, string end, string cabh, string bigname)
        {
            List<Model.Wanfa> list = dal.GetListArray("*", "isshow desc", pagesize, pageindex, GetCond(key, start, end, cabh, bigname));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                string czname = czdal.GetCZName(item.czid);
                arr.Add(new
                {
                    id = item.id,
                    createtime = item.createtime,
                    wfname = item.wfname,
                    remark = item.remark,
                    czid = item.czid,
                    czname = czname,
                    basemoney = item.basemoney,
                    groupname = item.groupname,
                    peilv = item.peilv,
                    isshow = item.isshow,
                    isshowremark = item.isshowremark,
                    bigname = item.bigname,
                    tesu = item.tesu,
                    tesu_peilv = item.tesu_peilv,
                    tesu_je = item.tesu_je,
                });
            }
            return Json(arr);
        }

        public ActionResult Add(int? id)
        {
            ViewBag.czlist = czdal.GetListArray("");
            Model.Wanfa n = new Model.Wanfa();
            if (id != null)
            {
                n = dal.GetModel(id.Value);
            }
            return View(n);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Model.Wanfa m)
        {
            try
            {
                if (m.id == 0)
                {
                    dal.Add(m);
                    return Json(new { code = 0, msg = "新增成功！" });
                }
                else
                {
                    dal.Update(m);
                    return Json(new { code = 0, msg = "编辑成功！" });
                }
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
    }
}
