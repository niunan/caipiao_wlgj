using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.Model
{
    /// <summary>
    /// 0中奖加款，1跟单扣款，2零点返还，3后台撤销跟单，4上分加款，5下分扣款,6补偿加款
    /// </summary>
  public   enum LiuShuiType {
        [Description("中奖加款")]
        ZhongJiang = 0,
        [Description("跟单扣款")]
        GengDan = 1,
        [Description("零点返还")]
        FanHuan = 2,
        [Description("后台撤销跟单")]
        CancelDan = 3,
        [Description("上分加款")]
        ShangFen = 4,
        [Description("下分扣款")]
        XiaFen = 5,
        [Description("补偿加款")]
        BuChang = 6
    }
}
