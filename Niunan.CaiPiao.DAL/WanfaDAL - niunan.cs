using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using Niunan.CaiPiao.Model;

namespace Niunan.CaiPiao.DAL
{
    /// <summary>[wanfa]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-02-02 12:59:25
    /// </summary>
    public partial class WanfaDAL
    {
        /// <summary>
        /// 根据ID取赔率
        /// </summary>
        /// <param name="wfid"></param>
        /// <returns></returns>
        public double GetPeiLv(int wfid) {
            Model.Wanfa wf = GetModel(wfid);
            if (wf==null)
            {
                return 0;
            }
            return wf.peilv;
        }


        /// <summary>
        /// 根据id取bigname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetBigName(int id)
        {
            string sql = "select top 1 bigname from wanfa where id=@id";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string str = conn.QueryFirstOrDefault<string>(sql, new { id = id });
                return str;
            }
        }

        /// <summary>
        /// distinct取数据
        /// </summary>
        /// <param name="fieldname"></param>
        /// <returns></returns>
        public List<Model.Wanfa> GetDistinct(string fieldname)
        {
            string sql = "select distinct " + fieldname + " from wanfa";
            using (var conn = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                List<Model.Wanfa> list = conn.Query<Model.Wanfa>(sql).ToList();
                return list;
            }
        }

 
    }
}

