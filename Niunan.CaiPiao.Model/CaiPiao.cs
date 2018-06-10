using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.Model
{
    /// <summary>
    /// 业务裸体类
    /// </summary>
  public  class CaiPiao
    {
        public int czid { set; get; }
        public string czname { set; get; }
        public string qihao { set; get; }
        public DateTime starttime { set; get; }
        public DateTime endtime { set; get; }
        public DateTime kjtime { set; get; }
        public string kjcode { set; get; }
        public string remark { set; get; }
    }
}
