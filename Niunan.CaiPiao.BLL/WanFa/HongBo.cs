using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 银河国际，红波
    /// </summary>
    public class HongBo : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的，红波:0,3,6,9,12,15,18,21,24
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            if (kjcode=="3"||kjcode=="6"||kjcode=="9"||kjcode=="12"||kjcode=="15"||kjcode=="18"||kjcode=="21"||kjcode=="24")
            {
                b = true;
            }
            return b;
        }
    }
}
