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
    public class HomeController : Controller
    {
        //用于读取网站静态文件目录
        private IHostingEnvironment hostingEnv;

 


        public HomeController(IHostingEnvironment env )
        {
            hostingEnv = env; 
        }

        public IActionResult Index()
        {
            int? adminid = HttpContext.Session.GetInt32("caipiao_adminid");
            if (adminid == null)
            {
                //末登录
                return Redirect("/Adnn1n/Login/");
            }
            return View();
        }

        public IActionResult Top()
        {
            string adminname = HttpContext.Session.GetString("adminusername");
            ViewBag.username = adminname;
            return View();
        }

        public IActionResult Left() { return View(); }

        public IActionResult Welcome()
        {
            return View();
        }

        /// <summary>
        /// layui编辑器里的上传图片功能 
        /// {
        ///   "code": 0 //0表示成功，其它失败
        ///   ,"msg": "" //提示信息 //一般上传失败后返回
        ///   ,"data": {
        ///     "src": "图片路径"
        ///     ,"title": "图片名称" //可选
        ///   }
        /// }
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ImgUpload()
        {
            var imgFile = Request.Form.Files[0];
            if (imgFile != null && !string.IsNullOrEmpty(imgFile.FileName))
            {
                long size = 0;
                string tempname = "";
                var filename = ContentDispositionHeaderValue
                                .Parse(imgFile.ContentDisposition)
                                .FileName
                                .Trim();
                var extname = filename.Substring(filename.LastIndexOf('.'), filename.Length - filename.LastIndexOf('.')); //扩展名，如.jpg

                extname = extname.Replace("\"", "");

                #region 判断后缀
                if (!extname.ToLower().Contains("jpg") && !extname.ToLower().Contains("png") && !extname.ToLower().Contains("gif"))
                {
                    return Json(new { code = 1, msg = "只允许上传jpg,png,gif格式的图片.", });
                }
                #endregion

                #region 判断大小
                long mb = imgFile.Length / 1024 / 1024; // MB
                if (mb > 5)
                {
                    return Json(new { code = 1, msg = "只允许上传小于 5MB 的图片.", });
                }
                #endregion

                var filename1 = System.Guid.NewGuid().ToString().Substring(0, 6) + extname;
                tempname = filename1;
                var path = hostingEnv.WebRootPath; //网站静态文件目录  wwwroot
                string dir = DateTime.Now.ToString("yyyyMMdd");
                //完整物理路径
                string wuli_path = path + $"{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}{dir}{Path.DirectorySeparatorChar}";
                if (!System.IO.Directory.Exists(wuli_path))
                {
                    System.IO.Directory.CreateDirectory(wuli_path);
                }
                filename = wuli_path + filename1;
                size += imgFile.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    imgFile.CopyTo(fs);
                    fs.Flush();
                }
                return Json(new { code = 0, msg = "上传成功", data = new { src = $"/upload/{dir}/{filename1}", title = filename1 } });
            }
            return Json(new { code = 1, msg = "上传失败", });
        }

        /// <summary>
        /// kindeditor在线编辑器的上传
        /// </summary>
        /// <returns></returns>
        public IActionResult KE_Upload()
        {


            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

            //最大文件大小
            int maxSize = 1000000;

            var imgFile = Request.Form.Files["imgFile"];

            if (imgFile == null)
            {
                return Content(showError("请选择文件。"));
            }

            String dirPath = hostingEnv.WebRootPath;
            if (!Directory.Exists(dirPath))
            {
                showError("上传目录不存在。");
            }


            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable["image"]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable["image"]) + "格式。");
            }

            //创建文件夹
            string dir = DateTime.Now.ToString("yyyyMMdd");
            //完整物理路径
            string wuli_path = hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}{dir}{Path.DirectorySeparatorChar}";
            if (!System.IO.Directory.Exists(wuli_path))
            {
                System.IO.Directory.CreateDirectory(wuli_path);
            }

            String newFileName = Guid.NewGuid().ToString().Substring(0, 6) + fileExt;
            String filePath = dirPath + newFileName;

            using (FileStream fs = System.IO.File.Create(wuli_path + newFileName))
            {
                imgFile.CopyTo(fs);
                fs.Flush();
            }

            String fileUrl = $"/upload/{dir}/" + newFileName;

            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = fileUrl;
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(hash));

        }

        private string showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(hash);
            return str;
        }

        /// <summary>
        /// wangeditor在线编辑器的上传
        /// {
        /// errno 即错误代码，0 表示没有错误。
        ///       如果有错误，errno != 0，可通过下文中的监听函数 fail 拿到该错误码进行自定义处理
        ///    errno: 0, 
        /// data 是一个数组，返回若干图片的线上地址
        ///data: [
        ///    '图片1地址',
        ///    '图片2地址',
        ///    '……'
        ///]
        ///}
        /// </summary>
        /// <returns></returns>
        public ActionResult WE_Upload()
        {


            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");

            //最大文件大小
            int maxSize = 1000000;

            var imgFile = Request.Form.Files[0];

            if (imgFile == null)
            {
                return Json(new { errno = 1, msg = "图片不存在" });
            }

            String dirPath = hostingEnv.WebRootPath;
            if (!Directory.Exists(dirPath))
            {
                return Json(new { errno = 1, msg = "上传目录不存在" });
            }


            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile.Length > maxSize)
            {
                return Json(new { errno = 1, msg = "上传文件大小超过限制" });
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable["image"]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                return Json(new { errno = 1, msg = "上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable["image"]) + "格式。" });
            }

            //创建文件夹
            string dir = DateTime.Now.ToString("yyyyMMdd");
            //完整物理路径
            string wuli_path = hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}{dir}{Path.DirectorySeparatorChar}";
            if (!System.IO.Directory.Exists(wuli_path))
            {
                System.IO.Directory.CreateDirectory(wuli_path);
            }

            String newFileName = Guid.NewGuid().ToString().Substring(0, 6) + fileExt;
            String filePath = dirPath + newFileName;

            using (FileStream fs = System.IO.File.Create(wuli_path + newFileName))
            {
                imgFile.CopyTo(fs);
                fs.Flush();
            }

            String fileUrl = $"/upload/{dir}/" + newFileName;

            string[] ss = new string[] { fileUrl, };

            return Json(new { errno = 0, data = ss });

        }


       /// <summary>
         /// 图形验证码
         /// </summary>
         /// <returns></returns>
         public IActionResult GenYZM([FromServices]VierificationCodeServices _vierificationCodeServices)
         {
             string code = "";
             System.IO.MemoryStream ms = _vierificationCodeServices.CreateYZM(out code);
             HttpContext.Session.SetString("Code", code);
             Response.Body.Dispose();
             return File(ms.ToArray(), @"image/png");
         }
}
}
