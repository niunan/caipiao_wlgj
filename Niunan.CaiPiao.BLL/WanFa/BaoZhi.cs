using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 豹子
    /// </summary>
    public class BaoZhi : IWanFaBLL
    {
        /// <summary>
        /// 组成开奖号的三个号码一样的就算是豹子中奖
        /// 另外写一个方法
        /// </summary>
        /// <param name="buycode"></param>
        /// <param name="kjcode"></param>
        /// <returns></returns>
        public bool IsZJ(string buycode, string kjcode)
        {
            throw new NotImplementedException();
        }

        public bool IsZJ(int code1, int code2, int code3)
        {
            if (code1 == code2 && code2 == code3)
            {
                return true;
            }
            return false;
        }
    }
}
