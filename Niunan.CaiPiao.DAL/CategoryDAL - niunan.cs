using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>category表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-04-30 14:46:19
    /// </summary>
    public partial class CategoryDAL
    {


        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Niunan.CaiPiao.Model.Category GetModelByBH(string bh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from category where bh=@bh limit 1");
            Niunan.CaiPiao.Model.Category model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.CaiPiao.Model.Category>(strSql.ToString(), new { bh = bh });

            }
            return model;
        }





    }
}

