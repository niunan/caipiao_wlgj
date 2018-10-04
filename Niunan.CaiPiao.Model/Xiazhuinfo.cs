using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>xiazhuinfo表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-22 13:43:53
	/// </summary>
	[Serializable]
	public partial class Xiazhuinfo
	{
		public Xiazhuinfo()
		{}
		private int _id ;
		/// <summary>下注信息表
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
		/// <summary>用户名
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		private int _czid  = 0;
		/// <summary>彩种ID
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
		private int _wfid  = 0;
		/// <summary>玩法ID
		/// 
		/// </summary>
		public int wfid
		{
			set{ _wfid=value;}
			get{return _wfid;}
		}
		private string _wfname ;
		/// <summary>玩法名称
		/// 
		/// </summary>
		public string wfname
		{
			set{ _wfname=value;}
			get{return _wfname;}
		}
		private string _buycode ;
		/// <summary>下注号码
		/// 
		/// </summary>
		public string buycode
		{
			set{ _buycode=value;}
			get{return _buycode;}
		}
		private double _beishu  = 1;
		/// <summary>倍数：0.5，0.8，1.2，1.5，2
		/// 
		/// </summary>
		public double beishu
		{
			set{ _beishu=value;}
			get{return _beishu;}
		}
		private double _buymoney  = 0;
		/// <summary>下注金额，不算手续费
		/// 
		/// </summary>
		public double buymoney
		{
			set{ _buymoney=value;}
			get{return _buymoney;}
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
		private string _qihao ;
		/// <summary>期号
		/// 
		/// </summary>
		public string qihao
		{
			set{ _qihao=value;}
			get{return _qihao;}
		}
		private int _iszj  = 0;
		/// <summary>0未开奖，1已中奖， 2未中奖
		/// 
		/// </summary>
		public int iszj
		{
			set{ _iszj=value;}
			get{return _iszj;}
		}
		private double _zjmoney  = 0;
		/// <summary>中奖金额，带本金
		/// 
		/// </summary>
		public double zjmoney
		{
			set{ _zjmoney=value;}
			get{return _zjmoney;}
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
		private double _shouxufee  = 0;
		/// <summary>手续费
		/// 
		/// </summary>
		public double shouxufee
		{
			set{ _shouxufee=value;}
			get{return _shouxufee;}
		}
		private string _czr ;
		/// <summary>
		/// 
		/// </summary>
		public string czr
		{
			set{ _czr=value;}
			get{return _czr;}
		}
		private DateTime _kjtime = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public DateTime kjtime
		{
			set{ _kjtime=value;}
			get{return _kjtime;}
		}
	}
}
