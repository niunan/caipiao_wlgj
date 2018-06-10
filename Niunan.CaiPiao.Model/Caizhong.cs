using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>caizhong表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-12-11 17:38:41
	/// </summary>
	[Serializable]
	public partial class Caizhong
	{
		public Caizhong()
		{}
		private int _id ;
		/// <summary>采种表
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private DateTime _createtime = DateTime.Now;
		/// <summary>创建时间
		/// 
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		private string _czname ;
		/// <summary>名称
		/// 
		/// </summary>
		public string czname
		{
			set{ _czname=value;}
			get{return _czname;}
		}
		private string _remark ;
		/// <summary>备注
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
	}
}
