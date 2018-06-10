using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>userinfo表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-03-06 11:22:54
	/// </summary>
	[Serializable]
	public partial class Userinfo
	{
		public Userinfo()
		{}
		private int _id ;
		/// <summary>用户信息表
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
		private string _username ;
		/// <summary>用户名
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		private string _email ;
		/// <summary>邮箱
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		private string _password ;
		/// <summary>密码
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		private string _txpassword ;
		/// <summary>提现密码
		/// 
		/// </summary>
		public string txpassword
		{
			set{ _txpassword=value;}
			get{return _txpassword;}
		}
		private string _mobile ;
		/// <summary>手机
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		private string _address ;
		/// <summary>地址
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		private string _bankno ;
		/// <summary>银行卡号
		/// 
		/// </summary>
		public string bankno
		{
			set{ _bankno=value;}
			get{return _bankno;}
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
		private string _remark ;
		/// <summary>备注
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		private int _status  = 0;
		/// <summary>0超级管理员，1非下注用户，2普通管理员，3可下注用户
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
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
		private string _idcard ;
		/// <summary>身份证号
		/// 
		/// </summary>
		public string idcard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		private double _balance  = 0;
		/// <summary>余额
		/// 
		/// </summary>
		public double balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		private string _password3 ;
		/// <summary>
		/// 
		/// </summary>
		public string password3
		{
			set{ _password3=value;}
			get{return _password3;}
		}
		private string _erweima ;
		/// <summary>
		/// 
		/// </summary>
		public string erweima
		{
			set{ _erweima=value;}
			get{return _erweima;}
		}
		private int _parentid  = 0;
		/// <summary>父级ID
		/// 
		/// </summary>
		public int parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		private string _parentname ;
		/// <summary>父级名称
		/// 
		/// </summary>
		public string parentname
		{
			set{ _parentname=value;}
			get{return _parentname;}
		}
		private string _parentpath ;
		/// <summary>父级路径，如,1,2,3,4,
		/// 
		/// </summary>
		public string parentpath
		{
			set{ _parentpath=value;}
			get{return _parentpath;}
		}
		private string _question ;
		/// <summary>
		/// 
		/// </summary>
		public string question
		{
			set{ _question=value;}
			get{return _question;}
		}
		private string _answer ;
		/// <summary>
		/// 
		/// </summary>
		public string answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
	}
}
