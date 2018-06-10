using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using Niunan.CaiPiao.Model;

namespace Niunan.CaiPiao.BLL
{
    public class BeiJing28 : ICaiPiaoBLL
    {

        public string ConnStr { set; get; }

        /// <summary>
        /// 兑奖
        /// </summary>
        /// <param name="xiazhuid"></param>
        /// <returns></returns>
        public string DuiJiang(int xiazhuid)
        {
            DAL.WanfaDAL wfdal = new DAL.WanfaDAL() { ConnStr = ConnStr};
            DAL.UserinfoDAL udal = new DAL.UserinfoDAL() { ConnStr = ConnStr };
            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL() { ConnStr = ConnStr };
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            DAL.LiushuiDAL lsdal = new DAL.LiushuiDAL() { ConnStr = ConnStr };
            DAL.ShuxingDAL sxdal = new DAL.ShuxingDAL() { ConnStr = ConnStr };
            Model.Shuxing sx = sxdal.GetModelByCond($"sxname='特殊号返还'");
            if (sx == null)
            {
                throw new Exception("属性表中没有特殊号返还配置，请联系程序猿！");
            }
            double bfb_teshu = double.Parse(sx.sxvalue);

            Model.Xiazhuinfo xz = xzdal.GetModel(xiazhuid);
            if (xz == null)
            {
                throw new Exception("下注记录为空！");
            }
            if (xz.czid != 1)
            {
                throw new Exception("彩种ID不符合！");
            }
            if (!string.IsNullOrEmpty(xz.kjcode))
            {
                throw new Exception("该下注记录已开奖过！");
            }
            if (xz.iszj != 0)
            {
                throw new Exception($"该下注记录状态不对，iszj={xz.iszj}！");
            }
            Model.Userinfo u = udal.GetModel(xz.userid);
            if (u == null)
            {
                throw new Exception("下注用户为空");
            }
            Model.Qihaoinfo qh = qhdal.GetModelByCond($"qihao='{xz.qihao}'");
            if (qh == null)
            {
                throw new Exception("没有当前期信息");
            }
            if (string.IsNullOrEmpty(qh.kjcode))
            {
                throw new Exception("当前期未开奖");
            }

            Model.Wanfa wf = wfdal.GetModel(xz.wfid);


            string return_str = "没有任何结果，请联系程序猿！！！";

            #region 根据玩法名称进行开奖
            if (xz.buycode.Contains("专家版"))
            {
                bool b = new BLL.WanFa.ZhuanJiaBan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * 2;
                    double shouxufee = xz.buymoney * 0.013; //手续费为中奖部署的金额的1.3%
                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0,xz.qihao);


                }
                else if (qh.kjcode == "13" || qh.kjcode == "14")
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * (bfb_teshu / 100);
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0,xz.qihao);


                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode.Contains("大版"))
            {
                bool b = new BLL.WanFa.DaBan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * 2;
                    double shouxufee = 0;
                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

 
                }
                else if (qh.kjcode == "13")
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * (bfb_teshu / 100);
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode.Contains("小版"))
            {
                bool b = new BLL.WanFa.XiaoBan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * 2;
                    double shouxufee = 0;
                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else if (qh.kjcode == "14")
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * (bfb_teshu / 100);

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


 
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode.Contains("单版"))
            {
                bool b = new BLL.WanFa.DanBan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * 2;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

 
                }
                else if (qh.kjcode == "14")
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * (bfb_teshu / 100);
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

 
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode.Contains("双版"))
            {
                bool b = new BLL.WanFa.ShuanBan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * 2;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


 
                }
                else if (qh.kjcode == "13")
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * (bfb_teshu / 100);
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


 
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (wf.groupname == "特码")
            {
                bool b = new BLL.WanFa.TeMa().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double peilv = wfdal.GetModel(xz.wfid).peilv; //赔率
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode == "小单包三边")
            {
                bool b = new BLL.WanFa.Bao3Bian_XiaoDan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了，总共返回客户400
                    double beforemoney = u.balance;
                    double zjmoney = 400;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


 
                }
                else if (qh.kjcode == "13")
                {
                    //中特殊号，只返100给客户
                    double beforemoney = u.balance;
                    double zjmoney = 100;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode == "小双包三边")
            {
                bool b = new BLL.WanFa.Bao3Bian_XiaoShuang().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了，总共返回客户400
                    double beforemoney = u.balance;
                    double zjmoney = 400;


                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode == "大双包三边")
            {
                bool b = new BLL.WanFa.Bao3Bian_DaShuang().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了，总共返回客户400
                    double beforemoney = u.balance;
                    double zjmoney = 400;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);


                }
                else if (qh.kjcode == "14")
                {
                    //中特殊号，返回100给客户
                    double beforemoney = u.balance;
                    double zjmoney = 100;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode == "大单包三边")
            {
                bool b = new BLL.WanFa.Bao3Bian_DaDan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了，总共返回客户400
                    double beforemoney = u.balance;
                    double zjmoney = 400;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }
            else if (xz.buycode == "极大")
            {
                bool b = new BLL.WanFa.JiDa().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    #region 中奖了
                    double peilv = wf.peilv; //赔率
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                    #endregion
                }
                else
                {
                    #region 没中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                    #endregion
                }

            }
            else if (xz.buycode == "极小")
            {
                bool b = new BLL.WanFa.JiXiao().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    #region 中奖了
                    double peilv = wf.peilv; //赔率
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * peilv;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                    #endregion
                }
                else
                {
                    #region 没中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                    #endregion
                }
            }
            else if (xz.buycode == "豹子")
            {
                bool b = new BLL.WanFa.BaoZhi().IsZJ(qh.code1, qh.code2, qh.code3);
                if (b)
                {
                    #region 中奖了
                    double peilv = wf.peilv; //赔率
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * peilv;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                    #endregion
                }
                else
                {
                    #region 没中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                    #endregion
                }
            }
            else if (xz.buycode == "大")
            {
                #region 银河国际的 

                bool b = new BLL.WanFa.Da().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;


                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id,2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "小")
            {
                #region 银河国际的 

                bool b = new BLL.WanFa.Xiao().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;

                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id,2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);

                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "单")
            {
                #region 银河国际的 

                bool b = new BLL.WanFa.Dan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "双")
            {

                #region 银河国际的 

                bool b = new BLL.WanFa.Shuan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "大单")
            {
                #region 银河国际的,15(含)以上的单数,特殊号14

                bool b = new BLL.WanFa.DaDan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "大双")
            {
                #region 银河国际的 

                bool b = new BLL.WanFa.DaShuan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "小单")
            {
                #region 银河国际的,13(含)以下的单数,特殊号14

                bool b = new BLL.WanFa.XiaoDan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else if (qh.kjcode == wf.tesu.ToString())
                {
                    //特殊号码,客户得回下注金额的55%
                    double beforemoney = u.balance;
                    double zjmoney = wf.tesu_peilv != -1 ? wf.tesu_peilv * xz.buymoney : wf.tesu_je;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 2, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "小双")
            {
                #region 银河国际的,14(含)以下的双数,特殊号13

                bool b = new BLL.WanFa.XiaoShuan().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "红波")
            {
                #region 银河国际的，红波:1.2.7.8.12.13.18.19.23.24.29.30.34.35.40.45.46 

                bool b = new BLL.WanFa.HongBo().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "蓝波")
            {
                #region 银河国际的，蓝波:3.4.9.10.14.15.20.25.26.31.36.37.41.42.47.48 

                bool b = new BLL.WanFa.LanBo().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else if (xz.buycode == "绿波")
            {
                #region 银河国际的，绿波:5.6.11.16.17.21.22.27.28.32.33.38.39.43.44.49 

                bool b = new BLL.WanFa.LuBo().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0;

                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                }
                else
                {
                    //末中奖
                    xz.iszj = 0;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj=0, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }

                #endregion
            }
            else
            {
                throw new Exception("下注号不对，无此玩法");
            }
            #endregion
 
            return return_str;
        }

        /// <summary>
        /// 根据时间取当前期号
        /// </summary>
        /// <returns></returns>
        public Model.CaiPiao GetCurrentModel()
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Model.Qihaoinfo qh = null;
            if (DateTime.Now.Hour>= 9 && DateTime.Now<=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:55:00")))
            {
                //在今天的9:00 ~ 23:55 之间的，取当前期号
                qh = new DAL.QihaoinfoDAL().GetModelByCond($"czid=1 and starttime<='{now}' and '{now}'<=kjtime ");
            }
            else
            {
                //在今天23:55 ~ 第二天的9:00之间的，取第二天的第一期
                string tmp = "";
                if (DateTime.Now.Hour==23 && DateTime.Now.Minute>=55)
                {
                    tmp = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    tmp = DateTime.Now.ToString("yyyy-MM-dd");
                }
                qh = new DAL.QihaoinfoDAL().GetModelByCond($"czid=1 and starttime between '{tmp + (" 00:00:00")}' and '{tmp+(" 23:59:59")}' order by qihao asc");
            }
            if (qh == null)
            {
                return null;
            }
            Model.CaiPiao cp = new Model.CaiPiao()
            {
                czid = 1,
                czname = "北京28",
                qihao = qh.qihao,
                starttime = qh.starttime,
                endtime = qh.endtime,
                kjtime = qh.kjtime,
                kjcode = qh.kjcode,
                remark = qh.remark
            };
            return cp;
        }

        public Model.CaiPiao GetModel(string qihao)
        {
            Model.Qihaoinfo qh = new DAL.QihaoinfoDAL().GetModelByCond($"czid=1 and qihao='{qihao}'");
            if (qh == null)
            {
                return null;
            }
            Model.CaiPiao cp = new Model.CaiPiao()
            {
                czid = 1,
                czname = "北京28",
                qihao = qh.qihao,
                starttime = qh.starttime,
                endtime = qh.endtime,
                kjtime = qh.kjtime,
                kjcode = qh.kjcode,
                remark = qh.remark
            };
            return cp;
        }

        public async Task<string> InsertKJCodeAsync(bool onlyfirst = false, string url = "http://bwlc.net/bulletin/prevkeno.html")
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = url;
            StringBuilder sb = new StringBuilder();

            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL() { ConnStr = ConnStr };
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr};
            int czid = 1;
            string czname = "北京28";

            #region 北京福彩网的抓取规则
            using (var document = await BrowsingContext.New(config).OpenAsync(address))
            {
                string allhtml = document.QuerySelector("body").InnerHtml;

             //   Util.Log.Info($"开始抓取开奖号，远程返回的HTML：{allhtml} <br /> \r\n");

                var cellSelector = "table.tb tr";
                var cells = document.QuerySelectorAll(cellSelector);



                foreach (var item in cells)
                {
                    string qihao = "";
                    string kjcode = "";
                    string kjtime = "";

                    if (item.InnerHtml.Contains("td"))
                    {
                        qihao = item.QuerySelector("td:nth-child(1)").TextContent;
                        kjcode = item.QuerySelector("td:nth-child(2)").TextContent;
                        kjtime = item.QuerySelector("td:nth-child(4)").TextContent;

                        Model.Qihaoinfo qihaoinfo = qhdal.GetModelByCond($"qihao='{qihao}' and czid={czid}");


                        if (qihaoinfo != null && !string.IsNullOrEmpty(qihaoinfo.kjcode))
                        {
                            sb.Append($"期号：{qihao}<span style='color:red;'>已存在</span><br /> \r\n");
                            if (onlyfirst)
                            {
                                break;
                            }
                            continue;
                        }

                        DateTime d = DateTime.Parse(kjtime);



                        string[] ss = kjcode.Split(',');
                        List<int> arr = new List<int>();
                        foreach (var s in ss)
                        {
                            arr.Add(int.Parse(s));
                        }
                        arr.Sort();
                        int shu1 = arr[0] + arr[1] + arr[2] + arr[3] + arr[4] + arr[5];
                        int shu2 = arr[6] + arr[7] + arr[8] + arr[9] + arr[10] + arr[11];
                        int shu3 = arr[12] + arr[13] + arr[14] + arr[15] + arr[16] + arr[17];
                        string real_kjcode = (shu1 % 10 + shu2 % 10 + shu3 % 10).ToString();
                        string remark = $"{shu1 % 10} + {shu2 % 10} + {shu3 % 10}";

                        if (qihaoinfo == null)
                        {
                            qhdal.Add(new Qihaoinfo()
                            {
                                czid = czid,
                                czname = czname,
                                createtime = DateTime.Now,
                                kjtime = d,
                                starttime = d.AddMinutes(-5),
                                endtime = d.AddMinutes(-2),
                                qihao = qihao,
                                kjcode2 = kjcode,
                                kjcode = real_kjcode,
                                remark = remark,
                                code1 = shu1 % 10,
                                code2 = shu2 % 10,
                                code3 = shu3 % 10
                            });
                        }
                        else
                        {
                            //期号存在，开奖号为空，修改
                            qihaoinfo.kjcode = real_kjcode;
                            qihaoinfo.kjcode2 = kjcode;
                            qihaoinfo.remark = remark;
                            qihaoinfo.code1 = shu1 % 10;
                            qihaoinfo.code2 = shu2 % 10;
                            qihaoinfo.code3 = shu3 % 10;
                            qhdal.Update(qihaoinfo);

                        }



                        sb.Append($"期号：{qihao}，开奖号：{kjcode}，开奖时间 ：{kjtime} <span style='color:green'>已插入</span><br /> \r\n");

                        #region 兑奖
                        sb.Append($"兑奖结果：<br />\r\n");
                        List<Model.Xiazhuinfo> list_xiazhu = xzdal.GetListArray($"czid=1 and qihao='{qihao}'", "id");
                        foreach (var xz in list_xiazhu)
                        {
                            try
                            {
                                string str = this.DuiJiang(xz.id);
                                //   sb.Append(str + "<br />\r\n");  前台用户也能采集，不显示每张跟单的兑奖结果
                            }
                            catch (Exception ex)
                            {
                                //   sb.Append($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                                //  Util.Log.Error($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                            }
                        }
                        #endregion

                        if (onlyfirst)
                        {
                            break;
                        }
                    }


                }

                //document.Close();
                //document.Dispose();
            }
            #endregion

            #region PC2820.com的抓取规则
            //address = "https://pc2820.com/";
            //using (var document = await BrowsingContext.New(config).OpenAsync(address))
            //{
            //    string allhtml = document.QuerySelector("body").InnerHtml;

            //    //  Util.Log.Info($"开始抓取开奖号，远程返回的HTML：{allhtml} <br /> \r\n");

            //    var firsttable = document.QuerySelector("table"); //第一个表格就是存期号，开奖时间，开奖号的
            //    var trs = firsttable.QuerySelectorAll("tr");
            //    foreach (var onetr in trs)
            //    {
            //        if (onetr.InnerHtml.Contains("td"))
            //        {
            //            string qihao = onetr.QuerySelector("td:nth-child(1)").TextContent;
            //            string kjtime = onetr.QuerySelector("td:nth-child(2)").TextContent;
            //            string remark = onetr.QuerySelector("td:nth-child(3)").TextContent;
            //            string code1 = "";
            //            string code2 = "";
            //            string code3 = "";
            //            string kjcode = "";

            //            Regex reg = new Regex(@"(\d+)\+(\d+)\+(\d+)=(\d+)");
            //            Match m = reg.Match(remark);
            //            if (m.Success)
            //            {
            //                code1 = m.Groups[1].Value;
            //                code2 = m.Groups[2].Value;
            //                code3 = m.Groups[3].Value;
            //                kjcode = m.Groups[4].Value;


            //                //  sb.Append("\r\n期号：" + qihao + "， 开奖时间：" + kjtime + "， 开奖号：" + code1 + " + " + code2 + " + " + code3 + " = " + kjcode);

            //                Model.Qihaoinfo qihaoinfo = qhdal.GetModelByCond($"qihao='{qihao}' and czid={czid}");


            //                if (qihaoinfo != null && !string.IsNullOrEmpty(qihaoinfo.kjcode))
            //                {
            //                    sb.Append($"期号：{qihao} <span style='color:red;'>已存在</span><br /> \r\n");
            //                    if (onlyfirst)
            //                    {
            //                        break;
            //                    }
            //                    continue;
            //                }
            //                DateTime d = DateTime.Parse(kjtime);

            //                if (qihaoinfo == null)
            //                {
            //                    qhdal.Add(new Qihaoinfo()
            //                    {
            //                        czid = czid,
            //                        czname = czname,
            //                        createtime = DateTime.Now,
            //                        kjtime = d,
            //                        starttime = d.AddMinutes(-5),
            //                        endtime = d.AddMinutes(-2),
            //                        qihao = qihao,
            //                        kjcode2 = "",
            //                        kjcode = kjcode,
            //                        remark = remark,
            //                        code1 = int.Parse(code1),
            //                        code2 = int.Parse(code2),
            //                        code3 = int.Parse(code3)
            //                    });
            //                }
            //                else
            //                {
            //                    //期号存在，开奖号为空，修改
            //                    qihaoinfo.kjcode = kjcode;
            //                    qihaoinfo.kjcode2 = "";
            //                    qihaoinfo.remark = remark;
            //                    qihaoinfo.code1 = int.Parse(code1);
            //                    qihaoinfo.code2 = int.Parse(code2);
            //                    qihaoinfo.code3 = int.Parse(code3);
            //                    qhdal.Update(qihaoinfo);

            //                }



            //                sb.Append($"期号：{qihao}，开奖号：{kjcode}，开奖时间 ：{kjtime} <span style='color:green'>已插入</span><br /> \r\n");

            //                #region 兑奖
            //                sb.Append($"兑奖结果：<br />\r\n");
            //                List<Model.Xiazhuinfo> list_xiazhu = xzdal.GetListArray($"czid=1 and qihao='{qihao}'", "id");
            //                foreach (var xz in list_xiazhu)
            //                {
            //                    try
            //                    {
            //                        string str = this.DuiJiang(xz.id);
            //                        //   sb.Append(str + "<br />\r\n");  前台用户也能采集，不显示每张跟单的兑奖结果
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        //   sb.Append($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
            //                        Util.Log.Error($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
            //                    }
            //                }
            //                #endregion

            //                if (onlyfirst)
            //                {
            //                    break;
            //                }
            //            }


            //        }
            //    }
            //}
            #endregion


            return sb.ToString();
        }

        public async Task<string> InsertQiHao(string qihao, DateTime starttime, int qishu)
        {
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL();
            StringBuilder sb = new StringBuilder();
            int success = 0;
            int exists = 0;
            for (int i = 0; i < qishu; i++)
            {
                if (i != 0)
                {
                    qihao = (int.Parse(qihao) + 1).ToString();
                    if (starttime.ToString("HH:mm") == "23:50")
                    {
                        //已经是当天最后一天了，下一个开始时间是明天的09:00
                        starttime = DateTime.Parse(starttime.AddDays(1).ToString("yyyy-MM-dd 09:00"));
                    }
                    else
                    {
                        starttime = starttime.AddMinutes(5);
                    }
                }
                int czid = 1;
                string czname = "北京28";
                DateTime endtime = starttime.AddMinutes(4);
                DateTime kjtime = starttime.AddMinutes(5);

                if (qhdal.CalcCount($"qihao='{qihao}'") == 0)
                {
                    qhdal.Add(new Qihaoinfo()
                    {
                        qihao = qihao,
                        createtime = DateTime.Now,
                        czid = czid,
                        czname = czname,
                        starttime = starttime,
                        endtime = endtime,
                        kjtime = kjtime,

                    });
                    success++;
                }
                else
                {
                    exists++;
                }
            }
            sb.Append($"成功插入{success}期期号，{exists}期期号已存在");
            return sb.ToString();
        }

    }
}
