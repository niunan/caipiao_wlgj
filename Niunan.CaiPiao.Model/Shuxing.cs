using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>shuxing表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-09 13:57:33
	/// </summary>
	[Serializable]
	public partial class Shuxing
	{
		public Shuxing()
		{}
		private int _id ;
		/// <summary>属性表
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
		private string _sxname ;
		/// <summary>属性名称
		/// 
		/// </summary>
		public string sxname
		{
			set{ _sxname=value;}
			get{return _sxname;}
		}
		private string _sxvalue ;
		/// <summary>属性值
		/// 
		/// </summary>
		public string sxvalue
		{
			set{ _sxvalue=value;}
			get{return _sxvalue;}
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
