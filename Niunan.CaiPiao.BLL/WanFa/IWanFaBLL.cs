using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// 玩法接口
    /// </summary>
    interface IWanFaBLL
    {
        /// <summary>
        /// 是否中奖
        /// </summary>
        /// <param name="buycode">购买的下注号</param>
        /// <param name="kjcode">开奖号</param>
        /// <returns></returns>
        bool IsZJ(string buycode, string kjcode);
 
    }
}
