using System;
namespace Niunan.CaiPiao.Model
{
    /// <summary>xiazhuinfo表实体类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-18 14:53:10
    /// </summary> 
    public partial class Xiazhuinfo
    {
        /// <summary>
        /// 0未开奖，1已中奖，2未中奖
        /// </summary>
        public string iszjremark
        {
            get
            {
                string str = "";
                switch (_iszj)
                {
                    case 0: 
                        str = "末中奖"; 
                        break;
                    case 1:
                        str = "已中奖";
                        break;
                    case 2:
                        str = "未中奖";
                        break; 
                    default:
                        break;
                }

                return str;
            }
        }
    }
}
