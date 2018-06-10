using System;
using System.Collections.Generic;
using System.Text;

 namespace Niunan.CaiPiao.Model {
        /// <summary>category表实体类
        /// 作者:牛腩(QQ:164423073)
        /// 创建时间:2018-04-30 14:45:17
        /// </summary>
        [Serializable]
        public partial class Category
        {
            public Category()
            { }
            private int _id;
            /// <summary>
            /// 
            /// </summary>
            public int id
            {
                set { _id = value; }
                get { return _id; }
            }
            private DateTime _createtime = DateTime.Now;
            /// <summary>
            /// 
            /// </summary>
            public DateTime createtime
            {
                set { _createtime = value; }
                get { return _createtime; }
            }
            private string _caname;
            /// <summary>
            /// 
            /// </summary>
            public string caname
            {
                set { _caname = value; }
                get { return _caname; }
            }
            private string _bh;
            /// <summary>
            /// 
            /// </summary>
            public string bh
            {
                set { _bh = value; }
                get { return _bh; }
            }
            private string _remark;
            /// <summary>
            /// 
            /// </summary>
            public string remark
            {
                set { _remark = value; }
                get { return _remark; }
            }
        }

}