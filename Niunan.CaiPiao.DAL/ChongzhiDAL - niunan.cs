using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using Niunan.CaiPiao.Model;

namespace Niunan.CaiPiao.DAL
{
    /// <summary>[chongzhi]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-02-08 17:51:12
    /// </summary>
    public partial class ChongzhiDAL
    {
        /// <summary>
        /// 后台上分，用上事务
        /// </summary>
        /// <param name="u"></param>
        /// <param name="ls"></param>
        public void AdminShangFen(Userinfo u, Liushui ls)
        {
            string sql1 = "update userinfo set balance=balance+@money where id=@userid";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [liushui](");
            strSql.Append(" [userid], [username], [beforemoney], [changemoney], [aftermoney], [remark], [type], [xzid], [txid], [czid], [fhdate], [czr]  )");
            strSql.Append(" values (");
            strSql.Append("  @userid, @username, @beforemoney, @changemoney, @aftermoney, @remark, @type, @xzid, @txid, @czid, @fhdate, @czr  ) returning id;");

            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                IDbTransaction tran = conn.BeginTransaction();
                try
                {
                    conn.Execute(sql1, new { money = ls.changemoney, userid = u.id }, tran);
                    conn.Execute(strSql.ToString(), ls, tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }


        }
    }
}

