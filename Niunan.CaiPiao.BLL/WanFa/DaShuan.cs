using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 大双
    /// </summary>
    public class DaShuan : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的,14以上的双数,特殊号14
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x>14 && x%2==0)
            {
                b = true;
            }
            return b;
        }
    }
}
