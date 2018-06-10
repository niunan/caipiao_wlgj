using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.Model
{
    /// <summary>
    /// 统计-不抺雷
    /// </summary>
    public class TongJi_BuMoLei
    {
        public string date { set; get; }
        public int userid { set; get; }
        public string username { set; get; }
        /// <summary>
        /// 含雷的总下注金额
        /// </summary>
        public double xztotal { set; get; }
        /// <summary>
        /// 含雷的中奖的总额 
        /// </summary>
        public double zjtotal { set; get; }
        /// <summary>
        /// 含雷的手续费总额
        /// </summary>
        public double sxfeetotal { set; get; }
        public double yinkui
        {
            get
            {
                return (zjtotal - (xztotal + sxfeetotal));
            }
        }
    }
}
