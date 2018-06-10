using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Util;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class TestController : Controller
    {

        DAL.CaizhongDAL czdal;
        DAL.EmailsetDAL emaildal;
        BLL.BeiJing28 bj28;
        BLL.BJPK10 pk10;
        public TestController(DAL.CaizhongDAL czdal,DAL.EmailsetDAL emaildal,BLL.BeiJing28 bj28,BLL.BJPK10 pk10)
        {
            this.bj28 = bj28;
            this.emaildal = emaildal;
            this.czdal = czdal;
            this.pk10 = pk10;
        }



        public IActionResult Index()
        {
            string str = "测试页啊啊啊";

            //int x = czdal.Add(new Model.Caizhong() { czname = "北京PK拾" });

            //str += "， 新加入的采种ID：" + x;

            return Content(str);
        }

        public IActionResult SendMail() {
            string title = "texzt "+DateTime.Now;
        string str =    Tool.SendMailBySendCloud("service@niunan888.com", "niunan.net@icloud.com", title, title);
            return Content("用sendcloud发邮件返回："+str);
        }

        public async Task<IActionResult> InsertKJCode() {
         string str = await  pk10.InsertKJCodeAsync();
            return Content(str);
        }
    }
}