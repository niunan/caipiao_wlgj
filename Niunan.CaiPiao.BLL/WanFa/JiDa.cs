using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 极大
    /// </summary>
    public class JiDa : IWanFaBLL
    {
        /// <summary>
        /// 开奖号是23，24，25，26，27都算中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            if (kjcode == "23" || kjcode == "24" || kjcode == "25" || kjcode == "26" || kjcode == "27")
            {
                b = true;
            }
            return b;
        }
    }
}
