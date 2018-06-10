using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace Niunan.CaiPiao.DAL
{
    /// <summary>[tixian]表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-28 13:44:18
    /// </summary>
    public partial class TixianDAL
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
    }
}

 