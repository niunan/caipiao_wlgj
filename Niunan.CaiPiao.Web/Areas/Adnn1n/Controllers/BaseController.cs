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
using Microsoft.AspNetCore.Mvc.Filters;
using Niunan.CaiPiao.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.CaiPiao.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class BaseController : Controller
    {

        DAL.UserinfoDAL udal;
        public BaseController(DAL.UserinfoDAL udal)
        {
            this.udal = udal;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetInt32("caipiao_adminid") == null)
            {
                var con = new ContentResult();

       

                string r = "登录超时，请重新登录！";

                con.Content = $"<script>alert('{r}');parent.location.href='/adnn1n/login'</script>";
                con.ContentType = "text/html;charset=utf-8";
                filterContext.Result = con;
            }
            base.OnActionExecuting(filterContext);
        }

        public Model.Userinfo GetLoginAdmin()
        {
            int adminid = HttpContext.Session.GetInt32("caipiao_adminid").Value;
            Model.Userinfo admin = udal.GetModel(adminid);
            return admin;
        }
    }
}
