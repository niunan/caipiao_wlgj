using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>tixian表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-02-27 14:49:08
	/// </summary>
	[Serializable]
	public partial class Tixian
	{
		public Tixian()
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
		private DateTime _createtime=DateTime.Now ;
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
		private double _money ;
		/// <summary>
		/// 
		/// </summary>
		public double money
		{
			set{ _money=value;}
			get{return _money;}
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
		private int _status ;
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		private string _replay ;
		/// <summary>
		/// 
		/// </summary>
		public string replay
		{
			set{ _replay=value;}
			get{return _replay;}
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
		private string _bankname ;
		/// <summary>
		/// 
		/// </summary>
		public string bankname
		{
			set{ _bankname=value;}
			get{return _bankname;}
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
		private int _userbankid  = 0;
		/// <summary>userbank表的ID
		/// 
		/// </summary>
		public int userbankid
		{
			set{ _userbankid=value;}
			get{return _userbankid;}
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
