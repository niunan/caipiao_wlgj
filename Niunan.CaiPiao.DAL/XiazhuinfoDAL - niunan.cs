using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[xiazhuinfo]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-11 17:38:42
    /// </summary>
    public partial class XiazhuinfoDAL
    {
        /// <summary>
        /// 下注中奖了更新下注表，用户表，流水表，用事务 来弄
        /// </summary>
        /// <returns></returns>
        public string ZhongJian(int xiazhuid, int xiazhu_iszj, double buymoney, double zjmoney, double shouxufee, string buycode, string kjcode, double beforemoney, int userid, string username, int liushui_type, string qihao)
        {
            double real_zjmoney = zjmoney - shouxufee;

            string remark = $"跟单【{xiazhuid}】【期号{qihao}】" + buycode + "中奖，跟单金额 " + buymoney + "，中奖金额" + zjmoney + ",手续费" + shouxufee + $",实际到账" + real_zjmoney;
            if (xiazhu_iszj == 2)
            {
                remark = $"跟单【{xiazhuid}】【期号{qihao}】" + buycode + "开出特殊号码，下注金额" + buymoney + $"，返还" + real_zjmoney;
            }


            string sql1 = $"update xiazhuinfo set iszj=@iszj,zjmoney=@zjmoney,kjcode=@kjcode,remark=@remark where id=@xiazhuid";
            string sql2 = $"update userinfo set balance=balance+@zjmoney where id=@userid";
            string sql3 = $"insert into liushui(userid,username,remark,type,beforemoney,changemoney,aftermoney,xzid) values(@userid,@username,@remark,@type,@beforemoney,@changemoney,@aftermoney,@xzid)";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                IDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    conn.Execute(sql1, new { iszj = xiazhu_iszj, zjmoney = real_zjmoney, kjcode = kjcode, remark = remark, xiazhuid = xiazhuid }, transaction);
                    conn.Execute(sql2, new { zjmoney = real_zjmoney, userid = userid }, transaction);
                    conn.Execute(sql3, new { userid = userid, username = username, remark = remark, type = liushui_type, beforemoney = beforemoney, changemoney = real_zjmoney, aftermoney = beforemoney + real_zjmoney, xzid = xiazhuid }, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw ex;
                }
            }
            return remark;
        }


        /// <summary>
        /// 测试事务
        /// </summary>
        /// <returns></returns>
        public string TestTran()
        {

            string sql1 = "update userinfo set balance=balance+10 where id=1";
            string sql2 = "update userinfo set balance=balance+10,question3='aaaa' where id=1"; //question3 字段不存在，这里会执行出错
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                IDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    conn.Execute(sql1, null, transaction);

                    conn.Execute(sql2, null, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    return "执行失败：" + ex.Message;
                }
                return "成功执行";
            }


        }

        /// <summary>
        /// 取不抺雷的统计报表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="startdate"></param>
        /// <returns></returns>
        public Model.TongJi_BuMoLei GetTongJiBuMoLei(int userid, DateTime startdate)
        {
            DateTime enddate = startdate.AddDays(7); //一周七天

            Model.Userinfo u = new DAL.UserinfoDAL().GetModel(userid);
            if (u == null)
            {
                throw new Exception("无此用户");
            }
            Model.TongJi_BuMoLei m = new Model.TongJi_BuMoLei()
            {
                date = startdate.ToString("yyyy-MM-dd") + " ~ " + enddate.ToString("yyyy-MM-dd"),
                userid = userid,
                username = u.username,
                xztotal = GetOneFiled_double("sum(buymoney)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1,2)"),
                sxfeetotal = GetOneFiled_double("sum(shouxufee)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1,2)"),
                zjtotal = GetOneFiled_double("sum(zjmoney)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1,2)"),

            };

            return m;

        }

        /// <summary> 
        /// 取抺雷的统计报表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="startdate"></param>
        /// <returns></returns>
        public Model.TongJi_BuMoLei GetTongJiMoLei(int userid, DateTime startdate)
        {
            DateTime enddate = startdate.AddDays(7); //一周七天

            Model.Userinfo u = new DAL.UserinfoDAL().GetModel(userid);
            if (u == null)
            {
                throw new Exception("无此用户");
            }
            Model.TongJi_BuMoLei m = new Model.TongJi_BuMoLei()
            {
                date = startdate.ToString("yyyy-MM-dd") + " ~ " + enddate.ToString("yyyy-MM-dd"),
                userid = userid,
                username = u.username,
                xztotal = GetOneFiled_double("sum(buymoney)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1)"),
                sxfeetotal = GetOneFiled_double("sum(shouxufee)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1)"),
                zjtotal = GetOneFiled_double("sum(zjmoney)", $"userid={userid} and kjtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and kjtime<='{enddate.ToString("yyyy-MM-dd 23:59:59")}' and iszj in (0,1)"),

            };

            return m;

        }

        /// <summary>
        /// 是否可以下注
        /// </summary>
        /// <param name="qihao">期号</param>
        /// <param name="userid">用户ID</param>
        /// <param name="buycode">玩法</param>
        /// <param name="buymoney">下注金额</param> 
        /// <returns>可以下注返回success,不可下注则返回原因</returns>
        public string CanXiaZhu(string qihao, int userid, string buycode, double buymoney)
        {

            string msg = "success";
            if (buycode == "小单" || buycode == "大双" || buycode == "大单" || buycode == "小双")
            {
                if (buymoney < 1 || buymoney > 50000)
                {
                    return "投注金额必须在【1 ~ 50000】";
                }
            }
            if (buycode == "大" || buycode == "小" || buycode == "单" || buycode == "双")
            {
                if (buymoney < 1 || buymoney > 100000)
                {
                    return "投注金额必须在【1 ~ 100000】";
                }
            }
            int x;
            if (int.TryParse(buycode, out x))
            {
                if (buymoney < 1 || buymoney > 20000)
                {
                    return "投注金额必须在【1 ~ 20000】";
                }
            }
            if (buycode == "红波" || buycode == "蓝波" || buycode == "绿波")
            {
                if (buymoney < 1 || buymoney > 10000)
                {
                    return "投注金额必须在【1 ~ 10000】";
                }
            }

            double all = GetOneFiled_double("sum(buymoney)", $"czid=1 and userid={userid} and qihao='{qihao}' and iszj in (0,1,2)");
            if (all + buymoney > 200000)
            {
                return $"您在第【{qihao}】期已下注【{all}】，单期投注总金额不能超过【200000】";
            }

            return msg;

        }

        /// <summary>
        /// 取一个字段，返回double类型
        /// </summary>
        /// <param name="fileds"></param>
        /// <param name="cond"></param>
        /// <returns></returns>
        public double GetOneFiled_double(string fileds, string cond)
        {
            string str = GetOneFiled(fileds, cond);
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return double.Parse(str);
        }
        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<Niunan.CaiPiao.Model.Xiazhuinfo> GetListArray(string strWhere, string fileds = "*")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select {fileds} ");
            strSql.Append(" FROM xiazhuinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Niunan.CaiPiao.Model.Xiazhuinfo> list = new List<Niunan.CaiPiao.Model.Xiazhuinfo>();
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.CaiPiao.Model.Xiazhuinfo>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>
        /// 下注
        /// </summary>
        /// <param name="userids">用户ID，以,间隔</param> 
        /// <param name="buycode">下注号码</param>
        /// <param name="buymoney">下注金额</param>
        /// <param name="beishu">倍数</param>
        /// <param name="qihao">期号</param>
        /// <param name="judgetime">是否判断时间，否的情况用于测试时批量下注</param>
        /// <param name="wfid">玩法ID</param>
        /// <param name="czid">采种ID</param>
        /// <returns>返回相关字符串</returns>
        public string XiaZhu(string userids,string buycode, double buymoney, double beishu, string qihao, bool judgetime, int wfid, int czid)
        {
            DAL.WanfaDAL wfdal = new WanfaDAL() { ConnStr = ConnStr };
            DAL.ShuxingDAL sxdal = new ShuxingDAL() { ConnStr = ConnStr };
            DAL.LiushuiDAL lsdal = new LiushuiDAL() { ConnStr = ConnStr };
            DAL.UserinfoDAL udal = new UserinfoDAL() { ConnStr = ConnStr };
            DAL.CaizhongDAL czdal = new CaizhongDAL() { ConnStr = ConnStr };
            DAL.QihaoinfoDAL qhdal = new QihaoinfoDAL() { ConnStr = ConnStr };

            Model.Caizhong cz = czdal.GetModel(czid);
            if (cz == null)
            {
                throw new Exception("采种不存在，请联系程序狗！");
            }


            double bfb_shouxufee = 0; //手续费百分比


            Model.Qihaoinfo qh =qhdal.GetModelByCond($"qihao='{qihao}'");
            if (qh == null)
            {
                throw new Exception("没有当前期号");
            }
            DateTime now = DateTime.Now;
            if (judgetime)
            {
                if (now < qh.starttime || now > qh.endtime)
                {
                    throw new Exception($"当前时间【{now.ToString("yyyy-MM-dd HH:mm:ss")}】不能下注，该期允许下注时间为【{qh.starttime.ToString("yyyy-MM-dd HH:mm:00")}】~【{qh.endtime.ToString("yyyy-MM-dd HH:mm:00")}】");
                }
            }
            double basemoney = 0;
            double shouxufee = 0; //手续费，不是专家版的马上扣

            string groupname = "";
            string wfname = "";
            Model.Wanfa wf = wfdal.GetModel(wfid);
            if (wf == null)
            {
                throw new Exception("玩法为空，请联系程序狗！");
            }
            wfname = wf.wfname;

            basemoney = buymoney;


            if (basemoney == 0)
            {
                throw new Exception("金额为空，请检查玩法名称。");
            }

      
            shouxufee = basemoney * (bfb_shouxufee / 100);

            StringBuilder sb = new StringBuilder();

            string[] ss = userids.Split(',');
            foreach (var item in ss)
            {
                int x;
                if (int.TryParse(item, out x))
                {
                    Model.Userinfo u = udal.GetModel(x);
                    if (u != null)
                    {
                        if (u.balance < (basemoney + shouxufee))
                        {
                            sb.Append($"用户【{u.username}】余额【{u.balance}】不足<br />\r\n");
                            continue;
                        }
                        int xzid = Add(new Model.Xiazhuinfo()
                        {
                            kjtime = qh.kjtime,
                            wfid = wfid,
                            wfname = wfname,
                            shouxufee = shouxufee,
                            beishu = beishu,
                            buycode = buycode,
                            buymoney = basemoney,
                            createtime = DateTime.Now,
                            czid = cz.id,
                            czname = cz.czname,
                            qihao = qihao,
                            userid = u.id,
                            username = u.username,
                        });
                        double beforemoney = u.balance;
                        u.balance -= basemoney + shouxufee;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui()
                        {

                            xzid = xzid,
                            type = 1,
                            beforemoney = beforemoney,
                            changemoney = basemoney + shouxufee,
                            aftermoney = u.balance,
                            createtime = DateTime.Now,
                            userid = u.id,
                            username = u.username,
                            remark = $"用户【{u.id} {u.username}】下注【{qihao}期】【{wfname}】，金额【{basemoney }+{shouxufee}】"
                        });


                        sb.Append($"用户【{u.username}】下注【{qihao}期】成功,玩法【{wfname}】，扣除余额【{basemoney + shouxufee}】<br />\r\n");
                    }//end if u!=null
                }//end if int.tryparse
            }//end foreach
            return sb.ToString();
        }

        /// <summary>
        /// APP下注
        /// </summary>
        /// <param name="userids"></param>
        /// <param name="wfname"></param>
        /// <param name="beishu"></param>
        /// <param name="qihao">期号</param>
        /// <param name="judgetime">是否判断时间，默认是，否的情况用于测试时批量下注</param>
        public string XiaZhu_APP(string userids, string wfname, double buymoney, double beishu, string qihao, bool judgetime = true, int wfid = 0)
        {
            DAL.WanfaDAL wfdal = new WanfaDAL();

            DAL.LiushuiDAL lsdal = new LiushuiDAL();
            Model.Qihaoinfo qh = new DAL.QihaoinfoDAL().GetModelByCond($"qihao='{qihao}'");
            if (qh == null)
            {
                throw new Exception("没有当前期号");
            }
            DateTime now = DateTime.Now;
            if (judgetime)
            {
                if (now < qh.starttime || now > qh.endtime)
                {
                    throw new Exception($"当前时间【{now.ToString("yyyy-MM-dd HH:mm:ss")}】不能下注，该期允许下注时间为【{qh.starttime.ToString("yyyy-MM-dd HH:mm:00")}】~【{qh.endtime.ToString("yyyy-MM-dd HH:mm:00")}】");
                }
            }

            Model.Wanfa wf = wfdal.GetModel(wfid);
            if (wf == null)
            {
                throw new Exception("无此玩法");
            }

            StringBuilder sb = new StringBuilder();
            DAL.UserinfoDAL udal = new UserinfoDAL();
            string[] ss = userids.Split(',');
            foreach (var item in ss)
            {
                int x;
                if (int.TryParse(item, out x))
                {
                    Model.Userinfo u = udal.GetModel(x);
                    if (u != null)
                    {
                        if (u.balance < buymoney)
                        {
                            sb.Append($"用户【{u.username}】余额【{u.balance}】不足<br />\r\n");
                            continue;
                        }
                        int xzid = Add(new Model.Xiazhuinfo()
                        {
                            kjtime = qh.kjtime,
                            wfid = wfid,
                            wfname = wf.wfname,
                            shouxufee = 0,
                            beishu = beishu,
                            buycode = wfname,
                            buymoney = buymoney,
                            createtime = DateTime.Now,
                            czid = 1,
                            czname = "北京28",
                            qihao = qihao,
                            userid = u.id,
                            username = u.username,
                        });
                        double beforemoney = u.balance;
                        u.balance -= buymoney;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui()
                        {

                            xzid = xzid,
                            type = 1,
                            beforemoney = beforemoney,
                            changemoney = buymoney,
                            aftermoney = u.balance,
                            createtime = DateTime.Now,
                            userid = u.id,
                            username = u.username,
                            remark = $"用户【{u.id} {u.username}】下注【{qihao}期】【{wfname}】，金额【{buymoney}】"
                        });


                        sb.Append($"用户【{u.username}】下注【{qihao}期】成功,玩法【{wfname}】，扣除余额【{buymoney}】<br />\r\n");
                    }//end if u!=null
                }//end if int.tryparse
            }//end foreach
            return sb.ToString();
        }

        /// <summary>
        /// 当日应该返还 的总额，预估，更新数据库的
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double Fa10Precent_YuGu(DateTime date)
        {
            DAL.UserinfoDAL udal = new UserinfoDAL();
            DAL.LiushuiDAL lsdal = new LiushuiDAL();
            DAL.ShuxingDAL sxdal = new ShuxingDAL();
            double baifenbi = double.Parse(sxdal.GetModelByCond($"sxname='零点返还'").sxvalue); //返还百分比，取出来的是还没有除以100的
            List<Model.Xiazhuinfo> list = GetListArray($"kjcode<>'' and createtime>='{date.ToString("yyyy-MM-dd 00:00:00")}' and createtime<='{date.ToString("yyyy-MM-dd 23:59:59")}'");
            double res = 0;
            var query = list.GroupBy(a => a.userid);
            foreach (var item in query)
            {
                int userid = item.Key;
                Model.Userinfo u = udal.GetModel(userid);
                if (u == null)
                {
                    continue;
                }
                var u_xz = list.Where(a => a.userid == userid); //该用户在该日的跟单
                double zhongjiang = 0; //中奖金额，以下注金额来算
                double weizhong = 0; //末中金额
                double fanhuan = 0; //返还的金额

                foreach (var xz in u_xz)
                {
                    if (xz.iszj == 0 && xz.buycode.Contains("专家版"))
                    {
                        //未中奖
                        weizhong += xz.buymoney;
                    }
                    else if (xz.iszj == 1)
                    {
                        //已中奖,只算中奖的，特殊号都不含 在里面
                        zhongjiang += xz.buymoney;
                    }
                }

                if (weizhong - zhongjiang > 0)
                {

                    fanhuan = (weizhong - zhongjiang) * (baifenbi / 100);
                }

                res += fanhuan;
            }
            return res;
        }

        /// <summary>
        /// 每日0：00返还10%的不中奖金额 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string Fa10Percent(int userid, DateTime startdate, DateTime enddate, bool insertdb = true, string czr = "")
        {
            DAL.UserinfoDAL udal = new UserinfoDAL();
            DAL.LiushuiDAL lsdal = new LiushuiDAL();
            DAL.ShuxingDAL sxdal = new ShuxingDAL();

            Model.Userinfo u = udal.GetModel(userid);
            if (u == null)
            {
                return "无此用户";
            }

            StringBuilder sb = new StringBuilder();
            double baifenbi = double.Parse(sxdal.GetModelByCond($"sxname='零点返还'").sxvalue); //返还百分比，取出来的是还没有除以100的

            while (startdate <= enddate)
            {

                #region 反还startdate当天的
                List<Model.Xiazhuinfo> list = GetListArray($"userid={userid} and iszj in (0,1,2) and kjcode<>'' and createtime>='{startdate.ToString("yyyy-MM-dd 00:00:00")}' and createtime<='{startdate.ToString("yyyy-MM-dd 23:59:59")}'"); //该用户在该日的跟单


                double zhongjiang = 0; //中奖金额，以下注金额来算
                double weizhong = 0; //末中金额
                double fanhuan = 0; //返还的金额

                foreach (var xz in list)
                {
                    if (xz.iszj == 0 && xz.buycode.Contains("专家版"))
                    {
                        //未中奖
                        weizhong += xz.buymoney;
                    }
                    else if (xz.iszj == 1)
                    {
                        //已中奖,只算中奖的，特殊号都不含 在里面
                        zhongjiang += xz.buymoney;
                    }
                }

                if (weizhong - zhongjiang > 0)
                {

                    fanhuan = (weizhong - zhongjiang) * (baifenbi / 100);
                }

                string remark = $"用户【{u.id} {u.username}】在 {startdate.ToString("yyyy-MM-dd 00:00:00")} ~ {startdate.ToString("yyyy-MM-dd 23:59:59")} 共跟单【{list.Count()}】次，专家版中奖金额【{zhongjiang}】，专家版+大小单双版未中金额【{weizhong}】，应返还：【({weizhong} - {zhongjiang})*{baifenbi}% = {fanhuan}】<br />\r\n";

                if (fanhuan > 0 && insertdb)
                {

                    //查type=2 and remark like '%%'没有才插
                    int x = lsdal.CalcCount($"type=2 and userid={u.id} and fhdate='{startdate.ToString("yyyy-MM-dd")}'");
                    if (x == 0)
                    {
                        double beforemoney = u.balance;
                        u.balance += fanhuan;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui() { type = 2, remark = remark, beforemoney = beforemoney, changemoney = fanhuan, aftermoney = u.balance, createtime = DateTime.Now, userid = u.id, username = u.username, fhdate = startdate.ToString("yyyy-MM-dd"), czr = czr });
                    }
                }

                sb.Append(remark);

                #endregion

                startdate = startdate.AddDays(1);
            }






            return sb.ToString();
        }

        /// <summary>
        /// 撤销跟单
        /// </summary>
        /// <param name="xzid"></param>
        /// <returns></returns>
        public string Cancel(int xzid, string remark, bool updatedb = true, string czr = "")
        {
            string str = "";
            Model.Xiazhuinfo xz = GetModel(xzid);
            if (xz == null)
            {
                return $"该跟单【{xzid}】不存在！";
            }
            if (xz.iszj == 3)
            {
                return $"该单【{xzid}】已撤销过，不准再次撤销";
            }
            DAL.UserinfoDAL udal = new UserinfoDAL();
            DAL.LiushuiDAL lsdal = new LiushuiDAL();
            Model.Userinfo u = udal.GetModel(xz.userid);
            if (string.IsNullOrEmpty(xz.kjcode))
            {
                #region 未开奖撤销
                double totalmoney = xz.buymoney + xz.shouxufee;

                double beforemoney = u.balance;
                str = $"撤销跟单【{xz.id}】，返还用户【{u.id} {u.username}】金额【{totalmoney}】（{xz.buymoney} + {xz.shouxufee}）";


                if (updatedb)
                {
                    xz.iszj = 3;
                    xz.remark = "后台撤销 " + remark;
                    Update(xz);


                    u.balance += totalmoney;
                    udal.Update(u);

                    lsdal.Add(new Model.Liushui()
                    {
                        remark = str,
                        userid = u.id,
                        username = u.username,
                        beforemoney = beforemoney,
                        changemoney = totalmoney,
                        aftermoney = u.balance,
                        createtime = DateTime.Now,
                        type = 3,
                        xzid = xz.id,
                        czr = czr,
                    });

                }
                #endregion
            }
            else
            {
                if (xz.iszj == 0)
                {
                    #region 已开奖未中奖

                    double totalmoney = xz.buymoney + xz.shouxufee;

                    double beforemoney = u.balance;
                    str = $"撤销跟单【{xz.id}】，返还用户【{u.id} {u.username}】金额【{totalmoney}】（{xz.buymoney} + {xz.shouxufee}）";

                    if (updatedb)
                    {
                        xz.iszj = 3;
                        xz.remark = "后台撤销 " + remark;
                        Update(xz);

                        u.balance += totalmoney;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui()
                        {
                            remark = str,
                            userid = u.id,
                            username = u.username,
                            beforemoney = beforemoney,
                            changemoney = totalmoney,
                            aftermoney = u.balance,
                            createtime = DateTime.Now,
                            type = 3,
                            xzid = xz.id,
                            czr = czr,
                        });

                    }


                    #endregion
                }
                else if (xz.iszj == 1)
                {
                    #region 已开奖已中奖

                    //例：下注2000，手续60，中奖，得4000， 那撤销应该是 余额 - 4000 + 2000 + 60
                    double totalmoney = -xz.zjmoney + (xz.buymoney + xz.shouxufee);

                    double beforemoney = u.balance;
                    str = $"撤销跟单【{xz.id}】，返还用户【{u.id} {u.username}】金额【{totalmoney}】（-{xz.zjmoney} + {xz.buymoney} +{xz.shouxufee}）";


                    if (updatedb)
                    {

                        xz.iszj = 3;
                        xz.remark = "后台撤销 " + remark;
                        Update(xz);


                        u.balance += totalmoney;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui()
                        {
                            remark = str,
                            userid = u.id,
                            username = u.username,
                            beforemoney = beforemoney,
                            changemoney = totalmoney,
                            aftermoney = u.balance,
                            createtime = DateTime.Now,
                            type = 3,
                            xzid = xz.id,
                            czr = czr,
                        });

                    }

                    #endregion
                }
                else if (xz.iszj == 2)
                {
                    #region 已开奖中特殊号

                    double totalmoney = -xz.zjmoney + xz.buymoney + xz.shouxufee;

                    double beforemoney = u.balance;

                    str = $"撤销跟单【{xz.id}】，返还用户【{u.id} {u.username}】金额【{totalmoney}】（-{xz.zjmoney} + {xz.buymoney} +{xz.shouxufee}）";


                    if (updatedb)
                    {
                        xz.iszj = 3;
                        xz.remark = "后台撤销 " + remark;
                        Update(xz);

                        u.balance += totalmoney;
                        udal.Update(u);

                        lsdal.Add(new Model.Liushui()
                        {
                            remark = str,
                            userid = u.id,
                            username = u.username,
                            beforemoney = beforemoney,
                            changemoney = totalmoney,
                            aftermoney = u.balance,
                            createtime = DateTime.Now,
                            type = 3,
                            xzid = xz.id,
                            czr = czr,
                        });
                    }

                    #endregion
                }
            }
            return str;
        }

        /// <summary>
        /// 计算某天的下注次数，
        /// wfid=0所有，1专家版，2大版，3小版，4单版，5双版
        /// </summary>
        /// <param name="date"></param>
        /// <param name="wfid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int CalcCount(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select count(1) from xiazhuinfo where kjtime>=@date1 and kjtime<@date2 and iszj in (0,1,2)"; //不要算撤销的
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = 0;

                i = conn.QueryFirst<int>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid });

                return i;
            }
        }

        /// <summary>
        /// 取某一天跟单总金额 wfid=0所有，1专家版，2大版，3小版，4单版，5双版
        /// </summary>
        public double GetGengDanJE(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(buymoney) from xiazhuinfo  where kjtime>=@date1 and kjtime<@date2 and iszj in (0,1,2)"; //不要算撤销的
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {

                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                double i = 0;

                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid });
                i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);

                return i;
            }
        }

        /// <summary>
        /// 取某一天的中奖总金额（不算特殊号返还） wfid=0所有，1专家版，2大版，3小版，4单版，5双版
        /// </summary>
        /// <param name="date"></param>
        /// <param name="wfid">0所有，1专家版，2大版，3小版，4单版，5双版</param>
        /// <returns></returns>
        public double GetZhongJiangJE(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(zjmoney) from xiazhuinfo  where kjtime>=@date1 and kjtime<@date2 and iszj=1"; //不要算撤销的
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                double i = 0;

                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid, });
                i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);

                return i;
            }
        }

        /// <summary>
        /// 取某一天的中奖总金额（算上特殊号返还） wfid=0所有，1专家版，2大版，3小版，4单版，5双版
        /// </summary>
        /// <param name="date"></param>
        /// <param name="wfid">0所有，1专家版，2大版，3小版，4单版，5双版</param>
        /// <returns></returns>
        public double GetZhongJiangJE_HasTeshu(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(zjmoney) from xiazhuinfo  where kjtime>=@date1 and kjtime<@date2 and iszj in (1,2)"; //不要算撤销的
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                double i = 0;

                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid, });
                i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);

                return i;
            }
        }

        /// <summary>
        /// 取开出特殊号返还的金额
        /// </summary>
        /// <param name="date"></param>
        /// <param name="wfid">0所有，1专家版，2大版，3小版，4单版，5双版</param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public double GetTeShuJE(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(zjmoney) from xiazhuinfo  where kjtime>=@date1 and kjtime<@date2 and iszj=2";
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }

            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                double i = 0;
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, userid = userid, wfid = wfid });
                i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);

                return i;
            }
        }

        /// <summary>
        /// 开出特殊号次数
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="wfid">0所有，1专家版，2大版，3小版，4单版，5双版</param>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public int GetTeShuCount(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select count(1) from xiazhuinfo where kjtime>=@date1 and kjtime<@date2 and iszj =2"; //不要算撤销的
            if (wfid != 0)
            {
                sql += " and wfid=@wfid";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = 0;

                i = conn.QueryFirst<int>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid });

                return i;
            }
        }

        /// <summary>
        /// 取某天大小单双版的手续费总额 wfid=0所有，1专家版，2大版，3小版，4单版，5双版
        /// </summary>
        /// <param name="date"></param>
        /// <param name="wfid"></param>
        /// <returns></returns>
        public double GetShouXuFee(DateTime date, int wfid = 0, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(shouxufee) from xiazhuinfo  where kjtime>=@date1 and kjtime<@date2  and iszj in (0,1,2)"; //不要算撤销的

            if (wfid != 0)
            {
                sql += " and wfid=@wfid ";
            }
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }

            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                double i = 0;
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, wfid = wfid, userid = userid, });
                i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);

                return i;
            }
        }




        /// <summary>
        /// 取一天的统计模型 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Model.VM_1DayTongJi Get1DayTongJiModel(DateTime date, int userid = 0)
        {
            DAL.LiushuiDAL lsdal = new DAL.LiushuiDAL();
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL();
            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL();
            Model.VM_1DayTongJi vm = new Model.VM_1DayTongJi()
            {
                date = date.ToString("yyyy-MM-dd"),

                zhong_count = xzdal.CalcCount(date, 0, userid),
                zhong_je = xzdal.GetGengDanJE(date, 0, userid),
                zhong_zjje = xzdal.GetZhongJiangJE(date, 0, userid),
                teshu_count = qhdal.GetTeShuCount(date),
                teshu_je = xzdal.GetTeShuJE(date, 0, userid),

                zhuangjia_count = xzdal.CalcCount(date, 1, userid),
                zhuangjia_je = xzdal.GetGengDanJE(date, 1, userid),
                zhuangjia_zjje = xzdal.GetZhongJiangJE(date, 1, userid),
                zhuangjia_teshu_count = xzdal.GetTeShuCount(date, 1, userid),
                zhuangjia_teshu_je = xzdal.GetTeShuJE(date, 1, userid),

                daban_count = xzdal.CalcCount(date, 2, userid),
                daban_je = xzdal.GetGengDanJE(date, 2, userid),
                daban_shouxufee = xzdal.GetShouXuFee(date, 2, userid),
                daban_zjje = xzdal.GetZhongJiangJE(date, 2, userid),
                daban_teshu_count = xzdal.GetTeShuCount(date, 2, userid),
                daban_teshu_je = xzdal.GetTeShuJE(date, 2, userid),

                xiaoban_count = xzdal.CalcCount(date, 3, userid),
                xiaoban_je = xzdal.GetGengDanJE(date, 3, userid),
                xiaoban_shouxufee = xzdal.GetShouXuFee(date, 3, userid),
                xiaoban_zjje = xzdal.GetZhongJiangJE(date, 3, userid),
                xiaoban_teshu_count = xzdal.GetTeShuCount(date, 3, userid),
                xiaoban_teshu_je = xzdal.GetTeShuJE(date, 3, userid),

                danban_count = xzdal.CalcCount(date, 4, userid),
                danban_je = xzdal.GetGengDanJE(date, 4, userid),
                danban_shouxufee = xzdal.GetShouXuFee(date, 4, userid),
                danban_zjje = xzdal.GetZhongJiangJE(date, 4, userid),
                danban_teshu_count = xzdal.GetTeShuCount(date, 4, userid),
                danban_teshu_je = xzdal.GetTeShuJE(date, 4, userid),

                shuangban_count = xzdal.CalcCount(date, 5, userid),
                shuangban_je = xzdal.GetGengDanJE(date, 5, userid),
                shuangban_shouxufee = xzdal.GetShouXuFee(date, 5, userid),
                shuangban_zjje = xzdal.GetZhongJiangJE(date, 5, userid),
                shuangban_teshu_count = xzdal.GetTeShuCount(date, 5, userid),
                shuangban_teshu_je = xzdal.GetTeShuJE(date, 5, userid),



                buchang_je = lsdal.GetBuChangJE(date, userid),
                lindianfanhuan_je = lsdal.GetFanHuan(date, userid),
                shangfen_je = lsdal.GetShangfenJE(date, userid),
                xiafen_je = lsdal.GetXiaFenJE(date, userid),



            };

            return vm;
        }


    }
}

