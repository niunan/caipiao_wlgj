using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>tixian表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-12-28 13:44:18
	/// </summary> 
	public partial class Tixian
	{ 
	 public string statusremark
        {
            get
            {
                string str = "";
                switch (status)
                {
                    case 0:
                        str = "审核中";
                        break;
                    case 1:
                        str = "下分成功";
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
