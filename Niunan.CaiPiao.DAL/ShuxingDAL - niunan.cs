using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[shuxing]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-01-09 13:57:34
    /// </summary>
    public partial class ShuxingDAL
    {
        /// <summary>
        /// 更新一条数据，有则更新，无则添加
        /// </summary>
        /// <param name="sxname"></param>
        /// <param name="sxvalue"></param>
        public void UpdateOne(string sxname, string sxvalue) {
            Model.Shuxing sx = GetModelByCond($"sxname='{sxname}'");
            if (sx==null)
            {
                Add(new Model.Shuxing() { sxname = sxname,sxvalue = sxvalue });
            }
            else
            {
                sx.sxvalue = sxvalue;
                Update(sx);
            }
        }

        /// <summary>
        /// 根据sxname取实体类
        /// </summary>
        /// <param name="sxname"></param>
        /// <returns></returns>
        public Model.Shuxing GetModelBySxName(string sxname) {
            string sql = "select * from shuxing where sxname=@sxname";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                Model.Shuxing sx = conn.QueryFirstOrDefault<Model.Shuxing>(sql, new { sxname = sxname });
                return sx;
            }
        }
    }
}

