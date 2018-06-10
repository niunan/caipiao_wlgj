using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>liushui表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-01-04 16:22:35
	/// </summary>
	[Serializable]
	public partial class Liushui
	{
		public Liushui()
		{}
		private int _id ;
		/// <summary>流水表
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
		private double _beforemoney  = 0;
		/// <summary>变更前金额
		/// 
		/// </summary>
		public double beforemoney
		{
			set{ _beforemoney=value;}
			get{return _beforemoney;}
		}
		private double _changemoney  = 0;
		/// <summary>变更金额
		/// 
		/// </summary>
		public double changemoney
		{
			set{ _changemoney=value;}
			get{return _changemoney;}
		}
		private double _aftermoney  = 0;
		/// <summary>变更后金额
		/// 
		/// </summary>
		public double aftermoney
		{
			set{ _aftermoney=value;}
			get{return _aftermoney;}
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
		private int _type  = 0;
		/// <summary>0中奖加款，1跟单扣款，2零点返还，3后台撤销跟单，4上分加款，5下分扣款
		/// 
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		private int _xzid  = 0;
		/// <summary>下注单ID
		/// 
		/// </summary>
		public int xzid
		{
			set{ _xzid=value;}
			get{return _xzid;}
		}
		private int _txid  = 0;
		/// <summary>提现单ID
		/// 
		/// </summary>
		public int txid
		{
			set{ _txid=value;}
			get{return _txid;}
		}
		private int _czid  = 0;
		/// <summary>充值单ID
		/// 
		/// </summary>
		public int czid
		{
			set{ _czid=value;}
			get{return _czid;}
		}
		private string _fhdate ;
		/// <summary>返还日期
		/// 
		/// </summary>
		public string fhdate
		{
			set{ _fhdate=value;}
			get{return _fhdate;}
		}
		private string _czr ;
		/// <summary>操作人
		/// 
		/// </summary>
		public string czr
		{
			set{ _czr=value;}
			get{return _czr;}
		}
	}
}
