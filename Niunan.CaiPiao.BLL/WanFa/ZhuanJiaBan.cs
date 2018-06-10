using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 专家版
    /// </summary>
    public class ZhuanJiaBan : IWanFaBLL
    {
        /// <summary>
        /// 大单，小双中奖，特殊号码13，14 
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            bool b = false;
            int x = int.Parse(kjcode);
            if (x == 15 || x == 17 || x == 19 || x == 21 || x == 23 || x == 25 || x == 27)
            {
                //大单 ，中奖
                b = true;
            } else if (x==0||x==2||x==4||x==6||x==8||x==10||x==12) {
                //小双，中奖
                b = true;
            }
            return b;
        }
    }
}
