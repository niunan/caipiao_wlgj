using System;
namespace Niunan.CaiPiao.Model
{
	/// <summary>news表实体类
	/// 作者:牛腩(QQ:164423073)
	/// 创建时间:2018-02-16 00:40:35
	/// </summary>
	[Serializable]
	public partial class News
	{
		public News()
		{}
		private int _id ;
		/// <summary>新闻表
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
		private string _title ;
		/// <summary>标题
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		private string _body ;
		/// <summary>内容
		/// 
		/// </summary>
		public string body
		{
			set{ _body=value;}
			get{return _body;}
		}
		private string _cabh ;
		/// <summary>分类编号
		/// 
		/// </summary>
		public string cabh
		{
			set{ _cabh=value;}
			get{return _cabh;}
		}
		private string _caname ;
		/// <summary>分类名称
		/// 
		/// </summary>
		public string caname
		{
			set{ _caname=value;}
			get{return _caname;}
		}
		private int _visitnum  = 0;
		/// <summary>访问量
		/// 
		/// </summary>
		public int visitnum
		{
			set{ _visitnum=value;}
			get{return _visitnum;}
		}
	}
}
