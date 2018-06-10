using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[admin_quanxian]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-01-05 14:30:32
    /// </summary>
    public partial class Admin_quanxianDAL
    {
        /// <summary>
        /// 管理员是否有某权限
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="qxid"></param>
        /// <returns></returns>
        public bool HasQX(int adminid, int qxid){
            bool b = false;
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "select count(1) from admin_quanxian where adminid=@adminid and qxid=@qxid";
             int res =   conn.QuerySingle<int>(sql, new { adminid = adminid, qxid = qxid });
                b = res > 0 ? true : false;
            }
            return b;
        }
 
    }
}

