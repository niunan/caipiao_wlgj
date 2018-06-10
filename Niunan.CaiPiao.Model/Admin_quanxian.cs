using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>admin_quanxian表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-05 14:30:32
	/// </summary>
	[Serializable]
	public partial class Admin_quanxian
	{
		public Admin_quanxian()
		{}
		private int _id ;
		/// <summary>管创理员权限表
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
		private int _qxid  = 0;
		/// <summary>权限ID
		/// 
		/// </summary>
		public int qxid
		{
			set{ _qxid=value;}
			get{return _qxid;}
		}
		private string _qxname ;
		/// <summary>权限
		/// 
		/// </summary>
		public string qxname
		{
			set{ _qxname=value;}
			get{return _qxname;}
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
