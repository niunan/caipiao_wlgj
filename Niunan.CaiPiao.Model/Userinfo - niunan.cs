using System;
namespace Niunan.CaiPiao.Model
{
    /// <summary>userinfo表实体类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2017-12-11 17:38:42
    /// </summary> 
    public partial class Userinfo
    {


        /// <summary>
        /// 0超级管理员，1非下注用户，2普通管理员，3可下注用户
        /// </summary>
        public string statusremark
        {
            get
            {
                string str = "";
                switch (_status)
                {
                    case 0:
                        str = "超级管理员";
                        break;
                    case 1:
                        str = "非下注用户";
                        break;
                    case 2:
                        str = "普通管理员";
                        break;
                    case 3:
                        str = "可下注用户";
                        break;
                    default:
                        break;
                }
                return str;
            }
        }


        public string ddltitle
        {
            get
            {
                if (_id==0)
                {
                    return "";
                }
                return _id + " " + _username + " ￥" + _balance;
            }
        }
    }
}
