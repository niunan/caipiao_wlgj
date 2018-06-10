using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>quanxian表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-05 14:30:32
	/// </summary>
	[Serializable]
	public partial class Quanxian
	{
		public Quanxian()
		{}
		private int _id ;
		/// <summary>权限名称表
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
		private string _qxname ;
		/// <summary>权限名称
		/// 
		/// </summary>
		public string qxname
		{
			set{ _qxname=value;}
			get{return _qxname;}
		}
		private string _url ;
		/// <summary>URL地址
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		private string _bh ;
		/// <summary>编号
		/// 
		/// </summary>
		public string bh
		{
			set{ _bh=value;}
			get{return _bh;}
		}
		private string _pbh ;
		/// <summary>父编号
		/// 
		/// </summary>
		public string pbh
		{
			set{ _pbh=value;}
			get{return _pbh;}
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
