using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 银河国际：蓝波
    /// </summary>
    public class LanBo : IWanFaBLL
    {
        /// <summary>
        /// 银河国际的，蓝波:2,5,8,11,17,20,23,26
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            if (kjcode=="2"||kjcode=="5"||kjcode=="8"||kjcode=="11"||kjcode=="17"||kjcode=="20"||kjcode=="23"||kjcode=="26" )
            {
                b = true;
            }
            return b;
        }
    }
}
