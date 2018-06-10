using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>userbank表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-02-27 11:00:44
	/// </summary>
	[Serializable]
	public partial class Userbank
	{
		public Userbank()
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
		private int _userid ;
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		private string _username ;
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		private string _bankname ;
		/// <summary>
		/// 
		/// </summary>
		public string bankname
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		private string _bankno ;
		/// <summary>
		/// 
		/// </summary>
		public string bankno
		{
			set{ _bankno=value;}
			get{return _bankno;}
		}
		private string _realname ;
		/// <summary>
		/// 
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		private string _remark ;
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		private string _khh ;
		/// <summary>开户行地址
		/// 
		/// </summary>
		public string khh
		{
			set{ _khh=value;}
			get{return _khh;}
		}
	}
}
