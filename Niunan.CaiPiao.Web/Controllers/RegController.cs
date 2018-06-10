using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.Util;
using Niunan.CaiPiao.Web.Models;

namespace Niunan.CaiPiao.Web.Controllers
{
    public class RegController : Controller
    {
        DAL.UserinfoDAL udal;
        public RegController(DAL.UserinfoDAL udal)
        {
            this.udal = udal;
        }


        public IActionResult Index()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Index(string username, string password, string txpassword, string realname, string parent_id, string email)
        {
            try
            {
                username = Tool.GetSafeSQL(username);
                email = Tool.GetSafeSQL(email);
                int x = udal.CalcCount($"username='{username}'");
                if (x > 0)
                {
                    return Json(new { code = 1, msg = "账号已存在" });
                }
                int i = 0;
                string parentname = "";
                string parentpath = "";
                if (int.TryParse(parent_id, out i))
                {
                    Model.Userinfo pu = udal.GetModel(i);
                    if (pu == null)
                    {
                        return Json(new { code = 1, msg = "没有该推荐人" });
                    }
                    else
                    {
                        parentname = pu.username;
                        parentpath = pu.parentpath + pu.id + ",";
                    }
                }
                if (udal.CalcCount($"email='{email}'") > 0)
                {
                    return Json(new { code = 1, msg = "邮箱重复" });
                }

                Model.Userinfo u = new Model.Userinfo()
                {
                    parentid = i,
                    email = email,
                    username = username,
                    password = Tool.MD5Hash(username + password + "caipiao"),
                    realname = realname,
                    parentpath = parentpath,
                    parentname = parentname,
                };
                int userid =udal.Add(u);
                u.id = userid;
                HttpContext.Session.SetInt32("caipiao_uerid", u.id);
                return Json(new { code = 0, msg = "注册成功" });

            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = "error: " + ex.Message });
            }
        }

    }
}
