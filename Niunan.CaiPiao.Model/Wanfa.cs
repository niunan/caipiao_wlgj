using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>wanfa表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-02-25 16:33:38
	/// </summary>
	[Serializable]
	public partial class Wanfa
	{
		public Wanfa()
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
		private DateTime _createtime = DateTime.Now ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		private string _wfname ;
		/// <summary>
		/// 
		/// </summary>
		public string wfname
		{
			set{ _wfname=value;}
			get{return _wfname;}
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
		private int _czid ;
		/// <summary>
		/// 
		/// </summary>
		public int czid
		{
			set{ _czid=value;}
			get{return _czid;}
		}
		private double _basemoney ;
		/// <summary>
		/// 
		/// </summary>
		public double basemoney
		{
			set{ _basemoney=value;}
			get{return _basemoney;}
		}
		private string _groupname ;
		/// <summary>
		/// 
		/// </summary>
		public string groupname
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		private double _peilv ;
		/// <summary>
		/// 
		/// </summary>
		public double peilv
		{
			set{ _peilv=value;}
			get{return _peilv;}
		}
		private int _isshow ;
		/// <summary>
		/// 
		/// </summary>
		public int isshow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		private string _shortname ;
		/// <summary>
		/// 
		/// </summary>
		public string shortname
		{
			set{ _shortname=value;}
			get{return _shortname;}
		}
		private int _sort ;
		/// <summary>
		/// 
		/// </summary>
		public int sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		private string _bigname ;
		/// <summary>大类名称，如霸王樽，乾坤袋，玲珑盒
		/// 
		/// </summary>
		public string bigname
		{
			set{ _bigname=value;}
			get{return _bigname;}
		}
		private int _tesu ;
		/// <summary>特殊号，-1是没有设置
		/// 
		/// </summary>
		public int tesu
		{
			set{ _tesu=value;}
			get{return _tesu;}
		}
		private double _tesu_peilv ;
		/// <summary>开出特殊号的赔率百分比，-1为没有设置
		/// 
		/// </summary>
		public double tesu_peilv
		{
			set{ _tesu_peilv=value;}
			get{return _tesu_peilv;}
		}
		private double _tesu_je ;
		/// <summary>开出特殊号返还的固定金额，-1为没有设置
		/// 
		/// </summary>
		public double tesu_je
		{
			set{ _tesu_je=value;}
			get{return _tesu_je;}
		}
	}
}
