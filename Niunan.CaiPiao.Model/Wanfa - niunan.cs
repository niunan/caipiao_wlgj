using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>wanfa表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-30 17:52:05
	/// </summary> 
	public partial class Wanfa
	{
	 
 
		/// <summary>1显示，0不显示
		/// 
		/// </summary>
		public string isshowremark
		{ 
			get{return _isshow==0?"停用":"启用";}
		}
	}
}
