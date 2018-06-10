using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 大单
    /// </summary>
    public class DaDan : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的,15(含)以上的单数,特殊号14
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x >= 15 && x % 2 != 0)
            {
                b = true;
            }
            return b;
        }
    }
}
