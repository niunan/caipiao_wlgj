using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 小双
    /// </summary>
   public class XiaoShuan : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的,14(含)以下的双数,特殊号13
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x<14&&x%2==0)
            {
                b = true;
            }
            return b;
        }
    }
}
