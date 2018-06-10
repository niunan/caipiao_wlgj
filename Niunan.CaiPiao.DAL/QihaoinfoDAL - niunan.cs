using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[qihaoinfo]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-12 15:08:22
    /// </summary>
    public partial class QihaoinfoDAL
    {
        /// <summary>
        /// 取走势图数据，当前期向下数100期
        /// </summary>
        /// <returns></returns>
        public List<Model.Qihaoinfo> GetZhouShiData(DateTime date,DateTime date2)
        {
            //string sql = "select top 100 * from qihaoinfo where qihao<(select qihao from qihaoinfo where starttime<getdate() and kjtime>getdate()) order by qihao desc";
            string sql = $"select * from qihaoinfo where starttime>='{date.ToString("yyyy-MM-dd 00:00:00")}' and starttime<='{date2.ToString("yyyy-MM-dd 23:59:59")}' order by qihao desc";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                List<Model.Qihaoinfo> list = conn.Query<Model.Qihaoinfo>(sql).ToList();
                return list;
            }
        }


        /// <summary>
        /// 取当天开出的特殊号次数
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetTeShuCount(DateTime date)
        {
            string date1 = date.ToString("yyyy-MM-dd");
            string date2 = date.AddDays(1).ToString("yyyy-MM-dd");
            string sql = "select count(1) from qihaoinfo where starttime>=@date1 and starttime<@date2 and (kjcode='13' or kjcode='14')";
            //string sql = "select count(1) from qihaoinfo where starttime>=@date1 and starttime<@date2 and kjcode in ('13','14')";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = conn.QueryFirst<int>(sql, new { date1 = date1, date2 = date2 });
                return i;
            }
        }

        /// <summary>
        /// 取今日的期数统计
        ///   <th>日期</th>
        //<th>总期数</th>
        //<th>大</th>
        //<th>小</th>
        //<th>单</th>
        //<th>双</th>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetQiShu(DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            List<Model.Qihaoinfo> list = GetListArray($"starttime>='{date.ToString("yyyy-MM-dd")}' and starttime<'{date.AddDays(1).ToString("yyyy-MM-dd")}' and czid=1");
            int da = 0, xiao = 0, dan = 0, shuang = 0;
            int zhong = 0, dadan = 0, xiaodan = 0, dashuang = 0, xiaoshuang = 0;
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.kjcode))
                {
                    int x = int.Parse(item.kjcode);
                    if (x > 13)
                    {
                        da++;
                    }
                    else
                    {
                        xiao++;
                    }

                    if (x % 2 == 0)
                    {
                        shuang++;
                    }
                    else
                    {
                        dan++;
                    }

                    if (x == 13 || x == 14)
                    {
                        zhong++;
                    }

                    if (x > 13 && x % 2 != 0)
                    {
                        dadan++;
                    }

                    if (x <= 13 && x % 2 != 0)
                    {
                        xiaodan++;
                    }

                    if (x >= 14 && x % 2 == 0)
                    {
                        dashuang++;
                    }
                    if (x < 14 && x % 2 == 0)
                    {
                        xiaoshuang++;
                    }

                }
            }

            sb.Append("<tr>");
            sb.Append($"<td>{date.ToString("yyyy-MM-dd")}</td>");
            sb.Append($"<td>{list.Count}</td>");
            sb.Append($"<td>{da}</td>");
            sb.Append($"<td>{xiao}</td>");
            sb.Append($"<td>{dan}</td>");
            sb.Append($"<td>{shuang}</td>");
            sb.Append($"<td>{zhong}</td>");
            sb.Append($"<td>{dadan}</td>");
            sb.Append($"<td>{xiaodan}</td>");
            sb.Append($"<td>{dashuang}</td>");
            sb.Append($"<td>{xiaoshuang}</td>");
            sb.Append("</tr>");
            return sb.ToString();
        }

        /// <summary>
        /// 根据期号取实体类
        /// </summary>
        /// <param name="qihao"></param>
        /// <returns></returns>
        public Model.Qihaoinfo GetModelByQiHao(string qihao) {
            string sql = "select * from qihaoinfo where qihao=@qihao";
            using (var conn =  ConnectionFactory.GetOpenConnection(ConnStr))
            {
                Model.Qihaoinfo qh = conn.QuerySingleOrDefault<Model.Qihaoinfo>(sql, new { qihao = qihao });
                return qh;
            }
        }
    }
}

