using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.Model
{
    /// <summary>
    /// 用户前台显示1天的统计模型
    /// </summary>
    public class VM_User_1DayTongJi
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string date { set; get; }
        /// <summary>
        /// 今日总跟单数，去掉撤销的,含特殊号的,
        /// </summary>
        public int zong_count { set; get; }
        /// <summary>
        /// 今日跟单总金额，去掉撤销的，含 特殊号的，含 大小单双版手续费
        /// </summary>
        public double zong_je { set; get; }
        /// <summary>
        /// 正常跟单总金额，不要算特殊号的，含大小单双版手续费
        /// </summary>
        public double zc_je { set; get; }
        /// <summary>
        /// 今日正常的中奖次数，不算特殊号
        /// </summary>
        public int zc_count { set; get; }
        /// <summary>
        /// 正常的未中奖次数，不算特殊号
        /// </summary>
        public int zc_nocount { set; get; }
        /// <summary>
        /// 正常跟单总次数，不算特殊号
        /// </summary>
        public int zc_zong_count
        {
            get
            {
                return zc_count + zc_nocount;
            }
        }
        /// <summary>
        /// 正常的中奖金额
        /// </summary>
        public double zc_zjje { set; get; }
        /// <summary>
        /// 今日中特殊号次数
        /// </summary>
        public int teshu_count { set; get; }
        /// <summary>
        /// 特殊号跟单金额
        /// </summary>
        public double teshu_gdje { set; get; }
        /// <summary>
        /// 特殊号返还的金额
        /// </summary>
        public double teshu_je { set; get; }
        /// <summary>
        /// 盈亏(-总跟单金额+正常中奖金额+正常特殊号返还金额） 
        /// 算开奖过的
        /// </summary>
        public double yinkui {
            set;get;
        }
        /// <summary>
        /// 用户今日的下分总额
        /// </summary>
        public double xiafen_je { set; get; }
    }
}
