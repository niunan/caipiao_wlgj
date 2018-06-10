using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 极小
    /// </summary>
    public class JiXiao : IWanFaBLL
    {
        /// <summary>
        /// 开奖号是0，1，2，3，4都算中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            if (kjcode == "0" || kjcode == "1" || kjcode == "2" || kjcode == "3" || kjcode == "4")
            {
                b = true;
            }
            return b;
        }
    }
}
