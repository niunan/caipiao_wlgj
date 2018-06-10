using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[caizhong]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-11 17:38:42
    /// </summary>
    public partial class CaizhongDAL
    {
        /// <summary>
        /// 取采种名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCZName(int id)
        {
            string sql = "select czname from caizhong where id = @id";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string czname = conn.Query<string>(sql, new { id = id }).FirstOrDefault();
                return czname;
            }
        }


    }
}

