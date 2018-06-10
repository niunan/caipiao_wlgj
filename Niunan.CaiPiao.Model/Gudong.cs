using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>gudong表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-04 00:33:34
	/// </summary>
	[Serializable]
	public partial class Gudong
	{
		public Gudong()
		{}
		private int _id ;
		/// <summary>股东表
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
		private string _username ;
		/// <summary>姓名
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		private string _email ;
		/// <summary>邮箱
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
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
