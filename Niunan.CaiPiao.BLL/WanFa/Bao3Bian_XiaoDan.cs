using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 小单包三边
    /// </summary>
    public class Bao3Bian_XiaoDan : IWanFaBLL
    {
        /// <summary>
        /// 只要不是小单的都算中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            int x = int.Parse(kjcode);
            if (x <= 13 && x % 2 != 0)
            {
                return false;
            }
            return true;
        }
    }
}
