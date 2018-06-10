using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[userinfo]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-11 17:38:42
    /// </summary>
    public partial class UserinfoDAL
    {
        /// <summary>
        /// 该邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistsEmail(string email)
        {
            string sql = "select count(1) from userinfo where email=@email";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = conn.QueryFirst<int>(sql, new { email = email });
                return i > 0;
            }
        }


        /// <summary>
        /// 取单个用户前台的统计
        ///      <th>日期</th>
        //<th>专家版跟单次数</th>
        //<th>银河国际专家版中奖次数</th>
        //<th>银河国际专家版盈利（次数*60）</th>
        //<th>太极专家版中奖次数</th>
        //<th>太极专家版盈利（次数*48.2）</th>
        //<th>开出特殊号次数</th>
        //<th>特殊号亏钱（-次数*310）</th>

        //<th>合计</th>
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetFrontTongJi(int userid, DateTime date)
        {
            DAL.XiazhuinfoDAL xzdal = new XiazhuinfoDAL();
            StringBuilder sb = new StringBuilder();

            int all_zj_count = xzdal.CalcCount(date, 1, userid); //所有专家版跟单次数
            int tj_zj_zjcount = xzdal.CalcCount($"userid={userid} and wfid=1 and iszj=1 and createtime>='{date.ToString("yyyy-MM-dd 00:00:00")}' and createtime<='{date.ToString("yyyy-MM-dd 23:59:59")}'"); //太极上的专家版中奖次数
            double tj_zj_je = tj_zj_zjcount * 48.2; //太极上的盈利
            int tj_teshu_count = xzdal.CalcCount($"userid={userid} and wfid=1 and iszj=2 and createtime>='{date.ToString("yyyy-MM-dd 00:00:00")}' and createtime<='{date.ToString("yyyy-MM-dd 23:59:59")}'"); //特殊号次数
            double tj_teshu_je = tj_teshu_count * 310; //特殊号亏的

            int yinhe_count = all_zj_count - tj_zj_zjcount; //银河国际赢的就是太极输的次数
            double yinhe_je = yinhe_count * 60;

            sb.Append("<tr>");
            sb.Append($"<td>{date.ToString("yyyy-MM-dd")}</td>");
            sb.Append($"<td>{all_zj_count}</td>");
            sb.Append($"<td>{yinhe_count}</td>");
            sb.Append($"<td>{yinhe_je}</td>");
            sb.Append($"<td>{tj_zj_zjcount}</td>");
            sb.Append($"<td>{tj_zj_je.ToString()}</td>");
            sb.Append($"<td>{tj_teshu_count}</td>");
            sb.Append($"<td>-{tj_teshu_je.ToString()}</td>");
            sb.Append($"<td>{yinhe_je + tj_zj_je - tj_teshu_je}</td>");
            sb.Append("</tr>");
            return sb.ToString();
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

        /// <summary>
        /// 取用户的跟单信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public string GetGengDanInfo(int userid, DateTime startdate, DateTime enddate)
        {
            string str = "";
            Model.Userinfo u = GetModel(userid);
            if (u == null)
            {
                return "";
            }
            Model.VM_User_1DayTongJi vm = GetVMUserMoreDayTongJi(startdate, enddate, userid);

            str = $"用户【{u.id} {u.username}】在【{vm.date}】跟单【{vm.zong_count}】次，跟单金额【{vm.zong_je}】，中奖金额【{vm.zc_zjje + vm.teshu_je}】，盈亏【{vm.yinkui}】";

            return str;
        }



        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Model.Userinfo Login(string username, string password)
        {
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "select * from userinfo where username=@username and password=@password";
                Model.Userinfo u = conn.QueryFirstOrDefault<Model.Userinfo>(sql, new { username = username, password = password });
                return u;
            }
        }


        /// <summary>
        /// 根据username取实体类
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Model.Userinfo GetModelByUsername(string username)
        {
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "select * from userinfo where username=@username";
                Model.Userinfo u = conn.QueryFirstOrDefault<Model.Userinfo>(sql, new { username = username });
                return u;
            }
        }


        /// <summary>
        /// 取用户一天的统计模型
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.VM_User_1DayTongJi GetVMUser1DayTongJi(DateTime date, int userid)
        {
            string date1 = date.ToString("yyyy-MM-dd 00:00:00");
            string date2 = date.ToString("yyyy-MM-dd 23:59:59");
            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL();
            DAL.LiushuiDAL lsdal = new DAL.LiushuiDAL();
            Model.VM_User_1DayTongJi vm = new Model.VM_User_1DayTongJi()
            {
                date = date.ToString("yyyy-MM-dd"),
                zong_count = xzdal.CalcCount($"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zong_je = xzdal.GetOneFiled_double("sum(buymoney+shouxufee)", $"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zc_je = xzdal.GetOneFiled_double("sum(buymoney+shouxufee)", $"userid={userid} and iszj in (0,1) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zc_count = xzdal.CalcCount($"userid={userid} and iszj=1 and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>'' "),
                zc_nocount = xzdal.CalcCount($"userid={userid} and iszj=0  and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>''"),
                zc_zjje = xzdal.GetOneFiled_double("sum(zjmoney)", $"userid={userid} and iszj=1 and kjtime>='{date1}' and kjtime<='{date2}' "),
                teshu_count = xzdal.CalcCount($"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>''"),
                teshu_je = xzdal.GetOneFiled_double("sum(zjmoney)", $"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' "),
                teshu_gdje = xzdal.GetOneFiled_double("sum(buymoney)", $"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' "),
                xiafen_je = lsdal.GetXiaFenJE(date, userid),
                yinkui = xzdal.GetOneFiled_double("sum(-(buymoney+shouxufee)+zjmoney)", $"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>'' "),
            };
            return vm;
        }

        /// <summary>
        /// 取用户多天的统计模型 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.VM_User_1DayTongJi GetVMUserMoreDayTongJi(DateTime startdate, DateTime enddate, int userid)
        {
            string date1 = startdate.ToString("yyyy-MM-dd HH:mm:ss");
            string date2 = enddate.ToString("yyyy-MM-dd HH:mm:ss");
            DAL.XiazhuinfoDAL xzdal = new DAL.XiazhuinfoDAL();
            DAL.LiushuiDAL lsdal = new DAL.LiushuiDAL();
            Model.VM_User_1DayTongJi vm = new Model.VM_User_1DayTongJi()
            {
                date = $"{date1} ~ {date2}",
                zong_count = xzdal.CalcCount($"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zong_je = xzdal.GetOneFiled_double("sum(buymoney+shouxufee)", $"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zc_je = xzdal.GetOneFiled_double("sum(buymoney+shouxufee)", $"userid={userid} and iszj in (0,1) and kjtime>='{date1}' and kjtime<='{date2}' "),
                zc_count = xzdal.CalcCount($"userid={userid} and iszj=1 and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>'' "),
                zc_nocount = xzdal.CalcCount($"userid={userid} and iszj=0  and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>''"),
                zc_zjje = xzdal.GetOneFiled_double("sum(zjmoney)", $"userid={userid} and iszj=1 and kjtime>='{date1}' and kjtime<='{date2}' "),
                teshu_count = xzdal.CalcCount($"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>''"),
                teshu_je = xzdal.GetOneFiled_double("sum(zjmoney)", $"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' "),
                teshu_gdje = xzdal.GetOneFiled_double("sum(buymoney)", $"userid={userid} and iszj=2 and kjtime>='{date1}' and kjtime<='{date2}' "),
                xiafen_je = lsdal.GetXiaFenJE(startdate, enddate, userid),
                yinkui = xzdal.GetOneFiled_double("sum(-(buymoney+shouxufee)+zjmoney)", $"userid={userid} and iszj in (0,1,2) and kjtime>='{date1}' and kjtime<='{date2}' and kjcode<>'' "),
            };
            return vm;
        }

 

    }
}

