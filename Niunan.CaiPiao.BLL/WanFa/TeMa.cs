using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 特码
    /// </summary>
    public class TeMa : IWanFaBLL
    {
        /// <summary>
        ///  特码，下单数字和开奖数字相同就中奖
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false; 
            if (buycode == kjcode)
            {
                b = true;
            }
            return b;
        }
    }
}
