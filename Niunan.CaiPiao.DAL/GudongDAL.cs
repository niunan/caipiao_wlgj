using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>gudong表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-01-04 00:33:34
    /// </summary>
    public partial class GudongDAL
    {
        /// <summary>
        /// 数据库连接字符串，从web层传入
        /// </summary>
        public string ConnStr { set; get; }
        public GudongDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(Niunan.CaiPiao.Model.Gudong model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gudong(");
            strSql.Append("createtime, username, email, remark  )");
            strSql.Append(" values (");
            strSql.Append("@createtime, @username, @email, @remark  ) returning id;"); 
 
    using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                   int i = connection.QueryFirst<int>(strSql.ToString(), model);
                return i;
            }
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(Niunan.CaiPiao.Model.Gudong model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gudong set ");
            strSql.Append("createtime=@createtime, username=@username, email=@email, remark=@remark  ");
            strSql.Append(" where id=@id ");
       using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString(), model);
                return i > 0;
            }
        }

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public bool UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gudong set "+str_set +" "); 
            strSql.Append(" where "+cond);
               using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gudong ");
            strSql.Append(" where id=@id ");
         using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {

                int i = connection.Execute(strSql.ToString(), new { id = id });
                return i > 0;
            }
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gudong ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
                 using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }
		
        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public string GetOneFiled(string filed, string cond)
        {
            string sql = "select " + filed + " from gudong";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
			
             using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string tmp = connection.ExecuteScalar<string>(sql);
                return tmp;
            }
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public Niunan.CaiPiao.Model.Gudong GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from gudong ");
            strSql.Append(" where id=@id ");
             Niunan.CaiPiao.Model.Gudong model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.CaiPiao.Model.Gudong>(strSql.ToString(), new { id=id });

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public Niunan.CaiPiao.Model.Gudong GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from gudong ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
        Niunan.CaiPiao.Model.Gudong model = null;
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                model = connection.QuerySingleOrDefault<Niunan.CaiPiao.Model.Gudong>(strSql.ToString());

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<Niunan.CaiPiao.Model.Gudong> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM gudong ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Niunan.CaiPiao.Model.Gudong> list = new List<Niunan.CaiPiao.Model.Gudong>();
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.CaiPiao.Model.Gudong>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<Niunan.CaiPiao.Model.Gudong> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        {
            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}", strWhere);

            string sql = string.Format("select {0} from gudong {1} order by {2} limit {3} OFFSET {4}", fileds, cond, orderstr, PageSize, (PageIndex - 1) * PageSize);
            // 	    string sql = string.Format("select {0} from gudong {1} order by {2} offset {3} rows fetch next {4} rows only", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);


            List<Niunan.CaiPiao.Model.Gudong> list = new List<Niunan.CaiPiao.Model.Gudong>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                list = connection.Query<Niunan.CaiPiao.Model.Gudong>(sql).ToList();

            }
            return list;
        }

 

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond )
        {
            string sql = "select count(1) from gudong";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
         using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int i = connection.QuerySingle<int>(sql);
                return i;

            }
        }
 
    }
}

