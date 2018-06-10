using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Niunan.CaiPiao.Util;
using System.Text;
using System.Net.Http;

namespace Niunan.CaiPiao.DAL
{
    /// <summary>`emailset`表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-09-28 18:54:37
    /// </summary>
    public partial class EmailsetDAL
    {
        
        /// <summary>
        /// 发统计邮件
        /// </summary>
        /// <returns></returns>
        public string FaTongJi(DateTime date, string front = "")
        {

            DAL.XiazhuinfoDAL xzdal = new XiazhuinfoDAL();

            //股东表里的才发邮件
            List<Model.Gudong> list = new DAL.GudongDAL().GetListArray("");
            //测试
            //   List<Model.Gudong> list = new DAL.GudongDAL().GetListArray("username='牛腩'");

            Model.VM_1DayTongJi vm = xzdal.Get1DayTongJiModel(date);

            StringBuilder sb = new StringBuilder();



            sb.Append("<table border='1'>");
            sb.Append("<tr>");
            sb.Append($"<td>日期</td>");
            sb.Append($"<td>{vm.date}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>跟单次数</td>");
            sb.Append($"<td>{vm.zhong_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>跟单总金额</td>");
            sb.Append($"<td>{vm.zhong_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>中奖总金额</td>");
            sb.Append($"<td>{vm.zhong_zjje}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>本日特殊号期数</td>");
            sb.Append($"<td>{vm.teshu_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>特殊中返还总额</td>");
            sb.Append($"<td>{vm.teshu_je}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>专家版跟单数</td>");
            sb.Append($"<td>{vm.zhuangjia_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>专家版跟单总额</td>");
            sb.Append($"<td>{vm.zhuangjia_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>专家版中奖额</td>");
            sb.Append($"<td>{vm.zhuangjia_zjje}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>大版跟单数</td>");
            sb.Append($"<td>{vm.daban_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>大版跟单总额</td>");
            sb.Append($"<td>{vm.daban_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>大版手续费总额</td>");
            sb.Append($"<td>{vm.daban_shouxufee}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>大版中奖总额</td>");
            sb.Append($"<td>{vm.daban_zjje}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>小版跟单数</td>");
            sb.Append($"<td>{vm.xiaoban_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>小版跟单总额</td>");
            sb.Append($"<td>{vm.xiaoban_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>小版手续费总额</td>");
            sb.Append($"<td>{vm.xiaoban_shouxufee}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>小版中奖总额</td>");
            sb.Append($"<td>{vm.daban_zjje}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>单版跟单数</td>");
            sb.Append($"<td>{vm.danban_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>单版跟单总额</td>");
            sb.Append($"<td>{vm.danban_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>单版手续费总额</td>");
            sb.Append($"<td>{vm.danban_shouxufee}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>单版中奖总额</td>");
            sb.Append($"<td>{vm.daban_zjje}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>双版跟单数</td>");
            sb.Append($"<td>{vm.shuangban_count}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>双版跟单总额</td>");
            sb.Append($"<td>{vm.shuangban_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>双版手续费总额</td>");
            sb.Append($"<td>{vm.shuangban_shouxufee}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>双版中奖总额</td>");
            sb.Append($"<td>{vm.shuangban_zjje}</td>");

            sb.Append("</tr><tr>");
            sb.Append($"<td>上分总额</td>");
            sb.Append($"<td>{vm.shangfen_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>补偿总额</td>");
            sb.Append($"<td>{vm.buchang_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>下分总额</td>");
            sb.Append($"<td>{vm.xiafen_je}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>下分手续费<br />（下分总额*1%）</td>");
            sb.Append($"<td>{vm.xiafen_shouxufee.ToString("f2")}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>零点返还总额</td>");
            sb.Append($"<td>{vm.lindianfanhuan_je.ToString("f2")}</td>");
            sb.Append("</tr><tr>");
            sb.Append($"<td>合计<br />(跟单-中奖-补偿-返还+下分手续费+各版手续版)</td>");

            sb.Append($"<td>{vm.heji.ToString("f2")}</td>");
            sb.Append($"</tr>");










            sb.Append("</table>");
            StringBuilder res = new StringBuilder();
            foreach (var item in list)
            {
                string title = front + date.ToString("yyyy-MM-dd") + "统计";
                string body = sb.ToString() ;
                try
                {

                    FaYouJian(title, body, item.email);

                    res.Append($"成功向股东【{item.username} {item.email}】发送统计邮件【{title}】<br />\r\n");
                }
                catch (Exception ex)
                {
                    res.Append($"向股东【{item.username} {item.email}】发统计邮件【{title}】失败【{ex.Message}】<br />\r\n");
                    try
                    {
                        //再发一次
                        FaYouJian(title, body, item.email);

                        res.Append($"重复成功向股东【{item.username} {item.email}】发送统计邮件【{title}】<br />\r\n");
                    }
                    catch (Exception ex2)
                    {
                        res.Append($"重复向股东【{item.username} {item.email}】发统计邮件【{title}】失败【{ex2.Message}】<br />\r\n");
                    }
                }
            }
            return res.ToString();
        }

        /// <summary>
        /// 取发件箱，cur=1，取完后移到一下位
        /// </summary>
        /// <returns></returns>
        public Model.Emailset GetFaJianXiang()
        {
            List<Model.Emailset> list = GetListArray("");
            if (list.Count == 0)
            {
                return null;
            }
            if (list.Count == 1)
            {
                return list[0];
            }
            Model.Emailset m = list.Where<Model.Emailset>(a => a.cur == 1).FirstOrDefault();
            if (m == null)
            {
                //没有cur=1的，取第一个，设置下一个cur=1 
                UpdateByCond("cur=1", $"id={list[1].id}");
                return list[0];
            }
            else
            {
                //返回，设置 下一个cur=1
                UpdateByCond("cur=0", "1=1");
                int index = list.IndexOf(m);
                index++;
                if (index < list.Count)
                {
                    UpdateByCond("cur=1", $"id={list[index].id}");
                }
                else
                {
                    UpdateByCond("cur=1", $"id={list[0].id}");
                }
                return m;
            }
        }

        /// <summary>
        /// 发邮件 
        /// </summary>
        public void FaYouJian(string title, string body, string toemail)
        {

            try
            {
                DAL.ShuxingDAL sxdal = new ShuxingDAL();
                Model.Shuxing sx = sxdal.GetModelByCond("sxname='use_sendcloud'");
                bool use_sendcloud = false;
                if (sx != null && sx.sxvalue != "0")
                {
                    use_sendcloud = true;
                }
                if (use_sendcloud)
                {
                    string sendcloud_fromemail = sxdal.GetOneFiled("sxvalue", "sxname='sendcloud_fromemail'");
                    string sendcloud_api_user = sxdal.GetOneFiled("sxvalue", $"sxname='sendcloud_api_user'");
                    string sendcloud_api_key = sxdal.GetOneFiled("sxvalue", $"sxname='sendcloud_api_key'");
                    string res = Tool.SendMailBySendCloud(sendcloud_fromemail, toemail, title, body,sendcloud_api_user,sendcloud_api_key);
                    if (res.Contains("成功"))
                    {

                    }
                    else
                    {
                        throw new Exception("sendcloud发邮件出错：" + res);
                    }
                }
                else
                {


                    Model.Emailset m_fa = GetFaJianXiang();
                    if (m_fa == null)
                    {
                        throw new Exception("发件配置为空");
                    }
                    string smtp = m_fa.smtp;
                    string from = m_fa.email;
                    string to = toemail;
                    string pwd = m_fa.password;
                    Tool.SendMail(title, body, to, from, from, pwd, smtp);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 向股东发邮件
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public string FaGuDongEmail(string title, string body)
        {
            List<Model.Gudong> list = new DAL.GudongDAL().GetListArray("");
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                try
                {
                    FaYouJian(title, body, item.email);
                    sb.Append($"向股东【{item.username} {item.email}】发邮件【{title}】成功");
                }
                catch (Exception ex)
                {
                    sb.Append($"向股东【{item.username} {item.email}】发邮件【{title}】失败【{ex.Message}】");
                }
            }
            return sb.ToString();
        }

    }
}

