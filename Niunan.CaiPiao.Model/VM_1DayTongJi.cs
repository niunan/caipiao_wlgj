using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.Model
{
    /// <summary>
    /// 视图模型，一天的统计
    /// </summary>
    public class VM_1DayTongJi
    {

        /// <summary>
        /// 日期
        /// </summary>
        public string date { set; get; }

        /// <summary>
        /// 总跟单数
        /// </summary>
        public int zhong_count { set; get; }

        /// <summary>
        /// 总跟单金额
        /// </summary>
        public double zhong_je { set; get; }
        /// <summary>
        /// 总的中奖金额
        /// </summary>
        public double zhong_zjje { set; get; }

        /// <summary>
        /// 专家版跟单数
        /// </summary>
        public int zhuangjia_count { set; get; }
        /// <summary>
        /// 专家版跟单金额
        /// </summary>
        public double zhuangjia_je { set; get; }
        /// <summary>
        /// 专家版中奖金额
        /// </summary>
        public double zhuangjia_zjje { set; get; }
        /// <summary>
        /// 专家版中特殊号次数
        /// </summary>
        public int zhuangjia_teshu_count { set; get; }
        /// <summary>
        /// 专家版中特殊号返还金额
        /// </summary>
        public double zhuangjia_teshu_je { set; get; }


        /// <summary>
        /// 大版跟单数
        /// </summary>
        public int daban_count { set; get; }
        /// <summary>
        /// 大版跟单金额
        /// </summary>
        public double daban_je { set; get; }
        /// <summary>
        /// 大版中奖金额
        /// </summary>
        public double daban_zjje { set; get; }
        /// <summary>
        /// 大版手续费合计
        /// </summary>
        public double daban_shouxufee { set; get; }
        /// <summary>
        /// 大版中特殊号次数
        /// </summary>
        public int daban_teshu_count { set; get; }
        /// <summary>
        /// 大版中特殊号返还金额
        /// </summary>
        public double daban_teshu_je { set; get; }

        /// <summary>
        /// 小版跟单数
        /// </summary>
        public int xiaoban_count { set; get; }
        /// <summary>
        /// 小版跟单金额
        /// </summary>
        public double xiaoban_je { set; get; }
        /// <summary>
        /// 小版中奖金额
        /// </summary>
        public double xiaoban_zjje { set; get; }
        /// <summary>
        /// 小版手续费合计
        /// </summary>
        public double xiaoban_shouxufee { set; get; }
        /// <summary>
        /// 小版中特殊号次数
        /// </summary>
        public int xiaoban_teshu_count { set; get; }
        /// <summary>
        /// 小版中特殊号返还金额
        /// </summary>
        public double xiaoban_teshu_je { set; get; }

        /// <summary>
        /// 单版跟单数
        /// </summary>
        public int danban_count { set; get; }
        /// <summary>
        /// 单版跟单金额
        /// </summary>
        public double danban_je { set; get; }
        /// <summary>
        /// 单版中奖金额
        /// </summary>
        public double danban_zjje { set; get; }
        /// <summary>
        /// 单版手续费合计
        /// </summary>
        public double danban_shouxufee { set; get; }
        /// <summary>
        /// 单版中特殊号次数
        /// </summary>
        public int danban_teshu_count { set; get; }
        /// <summary>
        /// 单版中特殊号返还金额
        /// </summary>
        public double danban_teshu_je { set; get; }

        /// <summary>
        /// 双版跟单数
        /// </summary>
        public int shuangban_count { set; get; }
        /// <summary>
        /// 双版跟单金额
        /// </summary>
        public double shuangban_je { set; get; }
        /// <summary>
        /// 双版中奖金额
        /// </summary>
        public double shuangban_zjje { set; get; }
        /// <summary>
        /// 双版手续费
        /// </summary>
        public double shuangban_shouxufee { set; get; }
        /// <summary>
        /// 双版中特殊号次数
        /// </summary>
        public int shuangban_teshu_count { set; get; }
        /// <summary>
        /// 双版中特殊号返还金额
        /// </summary>
        public double shuangban_teshu_je { set; get; }

        /// <summary>
        /// 本日开出特殊号期数（不管跟没跟单）
        /// </summary>
        public int teshu_count { set; get; }
        /// <summary>
        /// 特殊号返还给客户的金额
        /// </summary>
        public double teshu_je { set; get; }

        /// <summary>
        /// 上分总金额
        /// </summary>
        public double shangfen_je { set; get; }
        /// <summary>
        /// 补偿总金额
        /// </summary>
        public double buchang_je { set; get; }
        /// <summary>
        /// 下分总金额
        /// </summary>
        public double xiafen_je { set; get; }
        /// <summary>
        /// 下分手续费， 总金额 * 1%
        /// </summary>
        public double xiafen_shouxufee
        {
            get
            {
                return Math.Abs(xiafen_je) * 0.01;
            }
        }
        /// <summary>
        /// 零点返还总金额
        /// </summary>
        public double lindianfanhuan_je { set; get; }

        /// <summary>
        /// 合计：(跟单总额-中奖总额-特殊号返还总额-补偿总额-零点返还总额+下分手续费+各版手续费)
        /// </summary>
        public double heji
        {
            get
            {
                return zhong_je - zhong_zjje - teshu_je - buchang_je - lindianfanhuan_je + xiafen_shouxufee + daban_shouxufee + xiaoban_shouxufee + danban_shouxufee + shuangban_shouxufee;
            }
        }
    }
}
