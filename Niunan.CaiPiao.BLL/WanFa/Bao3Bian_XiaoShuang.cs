using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 小双包三边
    /// </summary>
    public class Bao3Bian_XiaoShuang : IWanFaBLL
    {
        /// <summary>
        /// 只要不是小双的都算中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            int x = int.Parse(kjcode);
            if (x < 14 && x % 2 == 0)
            {
                return false;
            }
            return true;
        }
    }
}
