using System;
using System.Collections.Generic;
using System.Text;

namespace Niunan.CaiPiao.BLL.WanFa
{
    /// <summary>
    /// pk10 猜冠军
    /// </summary>
    public class PK10_CaiGuangJun : IWanFaBLL
    {
        public bool IsZJ(string buycode, string kjcode)
        {
            if (kjcode.StartsWith(buycode))
            {
                return true;
            }
            return false;
        }
    }
}
