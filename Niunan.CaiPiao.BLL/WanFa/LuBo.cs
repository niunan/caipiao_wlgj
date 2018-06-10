using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 银河国际，绿波
    /// </summary>
    public class LuBo : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的，绿波:1,4,7,10,16,19,22,25
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            if (kjcode=="1"||kjcode=="4"||kjcode=="7"||kjcode=="10"||kjcode=="16"||kjcode=="19"||kjcode=="22"||kjcode=="25")
            {
                b = true;
            }
            return b;
        }
    }
}
