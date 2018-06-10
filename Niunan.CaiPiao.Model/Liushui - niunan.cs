using Niunan.CaiPiao.Util;
using System;
namespace Niunan.CaiPiao.Model
{
    /// <summary>liushui表实体类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-18 15:48:06
    /// </summary> 
    public partial class Liushui
    {
        /// <summary>
        /// 0中奖加款，1跟单扣款，2零点返还，3后台撤销跟单，4上分加款，5下分扣款,6补偿加款
        /// </summary>
        public string typeremark
        {
            get
            {
                string str = (typeof(LiuShuiType)).GetEnumDesc(_type);
                return str;
            }
        }
    }
}
