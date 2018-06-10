using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>emailset表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2017-12-27 17:26:37
	/// </summary>
	[Serializable]
	public partial class Emailset
	{
		public Emailset()
		{}
		private int _id ;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		private DateTime _createtime = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		private string _email ;
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		private string _password ;
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		private string _smtp ;
		/// <summary>
		/// 
		/// </summary>
		public string smtp
		{
			set{ _smtp=value;}
			get{return _smtp;}
		}
		private int _cur  = 0;
		/// <summary>
		/// 
		/// </summary>
		public int cur
		{
			set{ _cur=value;}
			get{return _cur;}
		}
	}
}
