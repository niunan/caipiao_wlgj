using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>news表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-02-16 00:40:36
    /// </summary>
    public partial class NewsDAL
    {



 /// <summary>
 /// 根据cabh取实体类
 /// </summary>
 /// <param name="cabh"></param>
 /// <returns></returns>
        public Niunan.CaiPiao.Model.News GetModelByCabh(string cabh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from news where cabh=@cabh limit 1");

            Niunan.CaiPiao.Model.News model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.CaiPiao.Model.News>(strSql.ToString(), new { cabh = cabh });

            }
            return model;
        }




    }
}

