using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 小版
    /// </summary>
    public class XiaoBan : IWanFaBLL
    {
        /// <summary>
        /// 小单，小双，特殊号码14，
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x<=13)
            {
                b = true;
            }
            return b;
        }
    }
}
