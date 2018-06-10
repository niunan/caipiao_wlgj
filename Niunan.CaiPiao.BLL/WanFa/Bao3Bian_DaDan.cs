using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 大单包三边
    /// </summary>
    public class Bao3Bian_DaDan : IWanFaBLL
    {
        /// <summary>
        /// 只要不是大单的都算中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            int x = int.Parse(kjcode);
            if (x > 13 && x % 2 != 0)
            {
                return false;
            }
            return true;
        }
    }
}
