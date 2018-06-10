using System;
namespace Niunan.CaiPiao.Model
{
    /// <summary>chongzhi表实体类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2018-01-04 16:10:20
    /// </summary> 
    public partial class Chongzhi
    { 
        public string paytyperemark
        {
            get { return _paytype == 1 ? "银联" : "支付宝"; }
        }

        public string statusremark
        {
            get
            {
                string str = "";
                switch (_status)
                {
                    case 0:
                        str = "审核中";
                        break;
                    case 1:
                        str = "上分成功";
                        break;
                    case 2:
                        str = "审核失败";
                        break;
                    default:
                        break;
                }
                return str;
            }
        }
    }
}
