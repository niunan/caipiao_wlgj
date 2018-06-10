using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>chongzhi表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-02-08 17:51:11
	/// </summary>
	[Serializable]
	public partial class Chongzhi
	{
		public Chongzhi()
		{}
		private int _id ;
		/// <summary>充值表
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
		private int _status  = 0;
		/// <summary>0初始，1充值成功，2审核失败,3待审核（后台已放音）
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
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
		private double _money  = 0;
		/// <summary>充值金额
		/// 
		/// </summary>
		public double money
		{
			set{ _money=value;}
			get{return _money;}
		}
		private string _bankname ;
		/// <summary>银行名称
		/// 
		/// </summary>
		public string bankname
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		private string _realname ;
		/// <summary>真实姓名
		/// 
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		private string _bankno ;
		/// <summary>银行卡号或者支付宝账号
		/// 
		/// </summary>
		public string bankno
		{
			set{ _bankno=value;}
			get{return _bankno;}
		}
		private int _paytype  = 0;
		/// <summary>1银联，2支付宝
		/// 
		/// </summary>
		public int paytype
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
	}
}
