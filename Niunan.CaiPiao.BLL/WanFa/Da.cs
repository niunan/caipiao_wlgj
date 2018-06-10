using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 银河国际，大
    /// </summary>
    public class Da : IWanFaBLL
    {
        /// <summary>
        ///   14特殊号码，14以上算中
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x>14)
            {
                b = true;
            }
            return b;
        }
    }
}
