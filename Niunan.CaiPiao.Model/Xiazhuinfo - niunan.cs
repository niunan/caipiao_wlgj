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
        /// 0末中奖，1已中奖，2特殊号，3后台撤销
        /// </summary>
        public string iszjremark
        {
            get
            {
                string str = "";
                switch (_iszj)
                {
                    case 0:
                        if (string.IsNullOrEmpty(_kjcode))
                        {
                            str = "待开奖";
                        }
                        else
                        {
                            str = "末中奖";
                        }
                        break;
                    case 1:
                        str = "已中奖";
                        break;
                    case 2:
                        str = "特殊号";
                        break;
                    case 3:
                        str = "后台撤销";
                        break;
                    default:
                        break;
                }

                return str;
            }
        }
    }
}
