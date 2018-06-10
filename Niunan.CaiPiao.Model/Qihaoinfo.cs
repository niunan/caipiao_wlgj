using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>qihaoinfo表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-17 21:20:35
	/// </summary>
	[Serializable]
	public partial class Qihaoinfo
	{
		public Qihaoinfo()
		{}
		private int _id ;
		/// <summary>期号信息表
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
		private string _qihao ;
		/// <summary>期号
		/// 
		/// </summary>
		public string qihao
		{
			set{ _qihao=value;}
			get{return _qihao;}
		}
		private DateTime _starttime = DateTime.Now;
		/// <summary>开始下注时间
		/// 
		/// </summary>
		public DateTime starttime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		private DateTime _endtime = DateTime.Now;
		/// <summary>结束下注时间
		/// 
		/// </summary>
		public DateTime endtime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		private DateTime _kjtime = DateTime.Now;
		/// <summary>开奖时间
		/// 
		/// </summary>
		public DateTime kjtime
		{
			set{ _kjtime=value;}
			get{return _kjtime;}
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
		private int _czid  = 0;
		/// <summary>采种ID
		/// 
		/// </summary>
		public int czid
		{
			set{ _czid=value;}
			get{return _czid;}
		}
		private string _czname ;
		/// <summary>彩种名称
		/// 
		/// </summary>
		public string czname
		{
			set{ _czname=value;}
			get{return _czname;}
		}
		private string _kjcode ;
		/// <summary>开奖号
		/// 
		/// </summary>
		public string kjcode
		{
			set{ _kjcode=value;}
			get{return _kjcode;}
		}
		private string _kjcode2 ;
		/// <summary>开奖号，用于记北京快8的二十个号码
		/// 
		/// </summary>
		public string kjcode2
		{
			set{ _kjcode2=value;}
			get{return _kjcode2;}
		}
		private int _code1  = 0;
		/// <summary>北京28第1位
		/// 
		/// </summary>
		public int code1
		{
			set{ _code1=value;}
			get{return _code1;}
		}
		private int _code2  = 0;
		/// <summary>北京28第2位
		/// 
		/// </summary>
		public int code2
		{
			set{ _code2=value;}
			get{return _code2;}
		}
		private int _code3  = 0;
		/// <summary>北京28第3位
		/// 
		/// </summary>
		public int code3
		{
			set{ _code3=value;}
			get{return _code3;}
		}
	}
}
