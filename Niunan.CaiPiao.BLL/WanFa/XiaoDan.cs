using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 小单
    /// </summary>
    public class XiaoDan : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的,13以下的单数,特殊号13
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x < 13 && x % 2 != 0)
            {
                b = true;
            }
            return b;
        }
    }
}
