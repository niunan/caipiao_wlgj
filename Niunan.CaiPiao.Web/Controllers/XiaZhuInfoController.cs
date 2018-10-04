using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.DAL;
using Niunan.CaiPiao.Util;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class XiaZhuInfoController : BaseController
    {
        DAL.XiazhuinfoDAL dal;
        DAL.WanfaDAL wfdal;

        public XiaZhuInfoController(UserinfoDAL udal, DAL.XiazhuinfoDAL dal, DAL.WanfaDAL wfdal) : base(udal)
        {
            this.dal = dal;
            this.wfdal = wfdal;
        }




        /// <summary>
        /// 下注
        /// </summary>
        /// <param name="code">下注号#注数#玩法ID#元角分#倍数$...</param>
        /// <param name="czid">采种ID</param>
        /// <param name="qihao">期号</param>
        /// <returns></returns>
        public IActionResult Add(string code, int czid, string qihao)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string userids = "1";//测试用，
                string[] ss = code.Split('$');
                foreach (var item in ss)
                {
                    string[] ss2 = item.Split('#');
                    string buycode = ss2[0];
                    int zhushu = int.Parse(ss2[1]);
                    int wfid = int.Parse(ss2[2]);
                    string yjf = ss2[3];
                    double beishu = double.Parse(ss2[4]);
                    Model.Wanfa wf = wfdal.GetModel(wfid);
                    if (wf == null)
                    {
                        continue;
                    }
                    double buymoney = 2 * zhushu * beishu; //下注金额=2*下注数*下注倍数

                    sb.Append(dal.XiaZhu(userids,buycode, buymoney, beishu, qihao, true, wfid, czid) + "<br />");
                }
                return Json(new { code = 0, msg = sb.ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = "err : " + ex.Message });
            }
        }

    }
}