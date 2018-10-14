using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using Niunan.CaiPiao.Model;

namespace Niunan.CaiPiao.BLL
{
    /// <summary>
    /// 北京PK10
    /// </summary>
    public class BJPK10 : ICaiPiaoBLL
    {
        public string ConnStr { set; get; }

        public string DuiJiang(int xiazhuid)
        {
            DAL.WanfaDAL wfdal = new DAL.WanfaDAL() { ConnStr = ConnStr };
            DAL.UserinfoDAL udal = new DAL.UserinfoDAL() { ConnStr = ConnStr };
            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL() { ConnStr = ConnStr };
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            DAL.LiushuiDAL lsdal = new DAL.LiushuiDAL() { ConnStr = ConnStr };
            DAL.ShuxingDAL sxdal = new DAL.ShuxingDAL() { ConnStr = ConnStr };
         
        
            Model.Xiazhuinfo xz = xzdal.GetModel(xiazhuid);
            if (xz == null)
            {
                throw new Exception("下注记录为空！");
            }
            if (xz.czid != 23)
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

            if (wf.wfname.Contains("猜冠军"))
            {
                bool b = new BLL.WanFa.PK10_CaiGuangJun().IsZJ(xz.buycode, qh.kjcode);
                if (b)
                {
                    //中奖了
                    double beforemoney = u.balance;
                    double zjmoney = xz.buymoney * wf.peilv;
                    double shouxufee = 0; //手续费为0
                    double real_zjmoney = zjmoney - shouxufee;


                    return_str = xzdal.ZhongJian(xz.id, 1, xz.buymoney, zjmoney, shouxufee, xz.buycode, qh.kjcode, beforemoney, xz.userid, xz.username, 0, xz.qihao);
                     
                }
                else
                {
                    //未中奖 
                    xz.iszj = 2;
                    xz.kjcode = qh.kjcode;
                    xzdal.UpdateByCond($"iszj={xz.iszj}, kjcode='{qh.kjcode}'", $"id={xz.id}");
                    return_str = $"订单【{xz.id}】未中奖";
                }
            }

            return return_str;
        }

        public Model.CaiPiao GetCurrentModel()
        {
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Model.Qihaoinfo qh = null;
            if (DateTime.Now.Hour >= 9 && DateTime.Now <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:55:00")))
            {
                //在今天的9:00 ~ 23:55 之间的，取当前期号
                qh = qhdal.GetModelByCond($"czid=23 and starttime<='{now}' and '{now}'<=kjtime ");
            }
            else
            {
                //在今天23:55 ~ 第二天的9:00之间的，取第二天的第一期
                string tmp = "";
                if (DateTime.Now.Hour == 23 && DateTime.Now.Minute >= 55)
                {
                    tmp = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    tmp = DateTime.Now.ToString("yyyy-MM-dd");
                }
                qh = qhdal.GetModelByCond($"czid=23 and starttime between '{tmp + (" 00:00:00")}' and '{tmp + (" 23:59:59")}' order by qihao asc");
            }
            if (qh == null)
            {
                return null;
            }
            Model.CaiPiao cp = new Model.CaiPiao()
            {
                czid = 23,
                czname = "北京PK拾",
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
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr }; 
            Model.Qihaoinfo qh = qhdal.GetModelByQiHaoAndCZID(qihao,23);
            
            if (qh == null)
            {
                return null;
            }
            Model.CaiPiao cp = new Model.CaiPiao()
            {
                czid = 23,
                czname = "北京PK拾",
                qihao = qh.qihao,
                starttime = qh.starttime,
                endtime = qh.endtime,
                kjtime = qh.kjtime,
                kjcode = qh.kjcode,
                remark = qh.remark
            };
            return cp;
        }

        public async Task<string> InsertKJCodeAsync(bool onlyfirst = false, string url = "http://www.bwlc.net/bulletin/trax.html?page=1")
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = url;
            StringBuilder sb = new StringBuilder();
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            int czid = 5;
            string czname = "北京PK拾";
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
                        kjtime = item.QuerySelector("td:nth-child(3)").TextContent;

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



                        if (qihaoinfo == null)
                        {
                            qhdal.Add(new Qihaoinfo()
                            {
                                czid = czid,
                                czname = czname,
                                createtime = DateTime.Now,
                                kjtime = d,
                                starttime = d.AddMinutes(-5),
                                endtime = d.AddMinutes(-1),
                                qihao = qihao,
                                kjcode = kjcode,
                            });
                        }
                        else
                        {
                            //期号存在，开奖号为空，修改
                            qihaoinfo.kjcode = kjcode;
                            qhdal.Update(qihaoinfo);

                        }



                        sb.Append($"[{czname}],期号：{qihao}，开奖号：{kjcode}，开奖时间 ：{kjtime} <span style='color:green'>已插入</span><br /> \r\n");

                        #region 兑奖
                        sb.Append($"兑奖结果：<br />\r\n");
                        //List<Model.Xiazhuinfo> list_xiazhu = xzdal.GetListArray($"czid=1 and qihao='{qihao}'", "id");
                        //foreach (var xz in list_xiazhu)
                        //{
                        //    try
                        //    {
                        //        string str = this.DuiJiang(xz.id);
                        //        //   sb.Append(str + "<br />\r\n");  前台用户也能采集，不显示每张跟单的兑奖结果
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        //   sb.Append($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                        //        //  Util.Log.Error($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                        //    }
                        //}
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
            return sb.ToString();
        }

        /// <summary>
        /// 插入期号
        /// 每天09:02 - 09:07 第一期
        /// 23:52-23:57 最后一期 
        /// </summary>
        /// <param name="qihao"></param>
        /// <param name="starttime"></param>
        /// <param name="qishu"></param>
        /// <returns></returns>
        public string InsertQiHao(string qihao, DateTime starttime, int qishu)
        {
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            StringBuilder sb = new StringBuilder();
            int success = 0;
            int exists = 0;
            for (int i = 0; i < qishu; i++)
            {
                if (i != 0)
                {
                    qihao = (long.Parse(qihao) + 1).ToString();
                    if (starttime.ToString("HH:mm") == "23:52")
                    {
                        //已经是当天最后一天了，下一个开始时间是明天的09:00
                        starttime = DateTime.Parse(starttime.AddDays(1).ToString("yyyy-MM-dd 09:02"));
                    }
                    else
                    {
                        starttime = starttime.AddMinutes(5);
                    }
                }
                int czid = 23;
                string czname = "北京PK拾";
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
