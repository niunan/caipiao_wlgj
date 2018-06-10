using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[liushui]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-28 13:44:18
    /// </summary>
    public partial class LiushuiDAL
    {
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
        /// 取当日的返还10%的总额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetFanHuan(DateTime date, int userid = 0)
        {
            string strdate = date.ToString("yyyy-MM-dd");
            return GetFanHuan(strdate, userid);
        }
        /// <summary>
        /// 取当日的返还10%的总额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetFanHuan(string date, int userid = 0)
        {
            string sql = "select sum(changemoney) from liushui where type=2 and fhdate=@fhdate";
            if (userid != 0)
            {

                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = conn.QueryFirst<string>(sql, new { fhdate = date, userid = userid });
                double i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
                return i;
            }
        }

        /// <summary>
        /// 取某日上分总额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetShangfenJE(DateTime date, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(changemoney) from liushui where type=4 and createtime>=@date1 and createtime<@date2";
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, userid = userid });
                double i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
                return i;
            }
        }

        /// <summary>
        /// 取某日下分总额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetXiaFenJE(DateTime date, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(changemoney) from liushui where type=5 and createtime>=@date1 and createtime<@date2";
            if (userid != 0)
            {
                sql += $" and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, userid = userid });
                double i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
                return i;
            }
        }

        /// <summary>
        /// 取某段时间下分总额
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public double GetXiaFenJE(DateTime startdate,DateTime enddate, int userid = 0)
        {
            string date1 = startdate.ToString("yyyy-MM-dd HH:mm:ss");
            string date2 = enddate.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "select sum(changemoney) from liushui where type=5 and createtime>=@date1 and createtime<@date2";
            if (userid != 0)
            {
                sql += $" and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, userid = userid });
                double i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
                return i;
            }
        }

        /// <summary>
        /// 取某日补偿总额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetBuChangJE(DateTime date, int userid = 0)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select sum(changemoney) from liushui where type=6 and createtime>=@date1 and createtime<@date2";
            if (userid != 0)
            {
                sql += " and userid=@userid";
            }
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = conn.QueryFirst<string>(sql, new { date1 = date1, date2 = date2, userid = userid, });
                double i = string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
                return i;
            }
        }
    }
}

