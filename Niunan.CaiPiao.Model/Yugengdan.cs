using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>yugengdan表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-04 23:58:03
	/// </summary>
	[Serializable]
	public partial class Yugengdan
	{
		public Yugengdan()
		{}
		private int _id ;
		/// <summary>预跟单
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
		private int _adminid  = 0;
		/// <summary>管理员ID
		/// 
		/// </summary>
		public int adminid
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		private string _adminname ;
		/// <summary>管理员姓名
		/// 
		/// </summary>
		public string adminname
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		private int _userid  = 0;
		/// <summary>用户ID
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		private string _username ;
		/// <summary>用户姓名
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
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
