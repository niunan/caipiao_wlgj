using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 单版
    /// </summary>
    public class DanBan : IWanFaBLL
    {
        /// <summary>
        /// 大单，小单，特殊号码14
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x%2==1)
            {
                b = true;
            }
            return b;
        }
    }
}
