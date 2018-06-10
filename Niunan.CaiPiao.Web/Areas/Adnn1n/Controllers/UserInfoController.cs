using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niunan.CaiPiao.DAL;
using Niunan.CaiPiao.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Niunan.CaiPiao.Web.Areas.Adnn1n.Controllers
{
    [Area("Adnn1n")]
    public class UserInfoController : BaseController
    {
        DAL.UserinfoDAL dal;
        DAL.LiushuiDAL lsdal;
        DAL.ChongzhiDAL czdal;
        DAL.TixianDAL txdal;
        DAL.YugengdanDAL yudal;
        DAL.QuanxianDAL qxdal;
        DAL.XiazhuinfoDAL xzdal;
        DAL.Admin_quanxianDAL admin_qxdal;

        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(Models.HttpGlobalExceptionFilter));

        public UserInfoController(UserinfoDAL udal,DAL.LiushuiDAL lsdal, DAL.ChongzhiDAL czdal, DAL.TixianDAL txdal, DAL.YugengdanDAL yudal,DAL.QuanxianDAL qxdal ,DAL.XiazhuinfoDAL xzdal , DAL.Admin_quanxianDAL admin_qxdal) : base(udal)
        {
            this.dal = udal;
            this.lsdal = lsdal;
            this.czdal = czdal;
            this.txdal = txdal;
            this.yudal = yudal;
            this.qxdal = qxdal;
            this.xzdal = xzdal;
            this.admin_qxdal = admin_qxdal;
        }


  

        public ActionResult Index()
        {
            ViewBag.admin = base.GetLoginAdmin();
            log.Info("进入/adnn1n/userinfo/index页面了");
            return View();
        }

        //加入预跟单
        public ActionResult Add_Yu(int userid)
        {
            try
            {
                Model.Userinfo admin = base.GetLoginAdmin();
                Model.Userinfo user = dal.GetModel(userid);
                if (yudal.CalcCount($"userid={userid} and adminid={admin.id}") == 0)
                {
                    yudal.Add(new Model.Yugengdan { userid = user.id, username = user.username, adminid = admin.id, adminname = admin.username, createtime = DateTime.Now, });
                }
                return Json(new { code = 0, msg = $"用户【{user.email}】加入预跟单成功！" });
            }
            catch (Exception ex)
            {

                return Json(new { code = 1, msg = "出错：" + ex.Message });
            }
        }

        //欢迎页输入三级密码显示用户近三天的统计
        public ActionResult ShowMX(string pwd3)
        {
            Model.Userinfo admin = base.GetLoginAdmin();
            pwd3 = Tool.MD5Hash(admin.username + pwd3 + "caipiao");
            if (admin.password3 != pwd3)
            {
                return Content("三级密码错误。");
            }
            ViewBag.userlist = dal.GetListArray("");
            return View();
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <returns></returns>
        public string GetCond(string key, string start, string end, string cabh, string email)
        {

            string cond = "id<>1";
            if (!string.IsNullOrEmpty(key))
            {
                key = Tool.GetSafeSQL(key);
                int x;
                if (int.TryParse(key, out x))
                {
                    cond += $" and id={x}";
                }

            }
            if (!string.IsNullOrEmpty(email))
            {
                email = Tool.GetSafeSQL(email);
                cond += $" and email like '%{email}%'";
            }
            /*     if (!string.IsNullOrEmpty(start))
             {
                 DateTime d;
                 if (DateTime.TryParse(start, out d))
                 {
                     cond += $" and createdate>='{d.ToString("yyyy-MM-dd")}'";
                 }
             }
             if (!string.IsNullOrEmpty(end))
             {
                 DateTime d;
                 if (DateTime.TryParse(end, out d))
                 {
                     cond += $" and createdate<='{d.ToString("yyyy-MM-dd")}'";
                 }
             }
             if (!string.IsNullOrEmpty(cabh))
             {
                 cabh = Tool.GetSafeSQL(cabh);
                 cond += $" and cabh='{cabh}'";
             }*/
            return cond;
        }

        /// <summary>
        /// 取总记录数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTotalCount(string key, string start, string end, string cabh, string email)
        {
            int totalcount = dal.CalcCount(GetCond(key, start, end, cabh, email));
            return Content(totalcount.ToString());
        }

        /// <summary>
        /// 取分页数据，返回 JSON
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public ActionResult List(int pageindex, int pagesize, string key, string start, string end, string cabh, string email)
        {
            string todaystr = DateTime.Now.ToString("yyyy-MM-dd");
            string tomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            List<Model.Userinfo> list = dal.GetListArray("*", "id desc", pagesize, pageindex, GetCond(key, start, end, cabh, email));
            ArrayList arr = new ArrayList();
            foreach (var item in list)
            {
                double cztotal = lsdal.GetOneFiled_double("sum(changemoney)", $"userid={item.id} and type=4 and createtime between '{todaystr}' and '{tomorrow}'");
                double txtotal = txdal.GetOneFiled_double("sum(money)", $"status=1 and userid={item.id} and createtime between '{todaystr}' and '{tomorrow}'");
                int xztotal = xzdal.CalcCount($"userid={item.id} and iszj in (0,1,2)");

                string quanxian = "";
                List<Model.Admin_quanxian> list_qx = admin_qxdal.GetListArray($"adminid={item.id}");
                if (list_qx.Count > 0)
                {
                    quanxian += "（";
                    foreach (var one_qx in list_qx)
                    {
                        quanxian += one_qx.qxname + ",";
                    }
                    quanxian += "）";
                }

                arr.Add(new
                {
                    idstr = item.id.ToString("d5"),
                    id = item.id,
                    createtime = item.createtime.ToString("yyyy-MM-dd HH:mm:ss"),
                    username = item.username,
                    email = item.email,
                    password = item.password,
                    txpassword = item.txpassword,
                    mobile = item.mobile,
                    address = item.address,
                    bankno = item.bankno,
                    bankname = item.bankname,
                    remark = item.remark,
                    status = item.status,
                    statusremark = item.statusremark + quanxian,
                    realname = item.realname,
                    idcard = item.idcard,
                    balance = item.balance,
                    cztotal = cztotal,
                    txtotal = txtotal,
                    xztotal = xztotal,
                    parentname = item.parentname,
                });
            }
            return Json(arr);
        }

        public ActionResult Add(int? id)
        {
            ViewBag.admin = base.GetLoginAdmin();

            ViewBag.quanxian = qxdal.GetListArray("url='' or url is null order by bh");

            List<Model.Userinfo> list_u = dal.GetListArray("1=1 order by username asc");
            list_u.Insert(0, new Model.Userinfo() { id = 0, username = "--无--" });
            ViewBag.parentlist = list_u;


            Model.Userinfo n = new Model.Userinfo() { status = 1 };
            if (id != null)
            {
                n = dal.GetModel(id.Value);
            }
            return View(n);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Model.Userinfo m)
        {
            m.email = Tool.GetSafeSQL(m.email);

            int parentid = m.parentid;
            string parentname = "";
            string parentpath = "";
            Model.Userinfo u_p = dal.GetModel(parentid);
            if (u_p != null)
            {
                parentid = u_p.id;
                parentname = u_p.username;
                parentpath = string.IsNullOrEmpty(u_p.parentpath) ? $",{u_p.id}," : $"{u_p.parentpath},{u_p.id},";
            }


            try
            {
                if (m.id == 0)
                {

                    m.username = m.email;
                    if (dal.CalcCount($"username='{m.username}'") > 0)
                    {
                        return Json(new { code = 1, msg = "用户名重复！" });
                    }
                    m.parentid = parentid;
                    m.parentname = parentname;
                    m.parentpath = parentpath;
                    m.password = Tool.MD5Hash(m.username + m.password + "caipiao");
                    m.txpassword = Tool.MD5Hash(m.username + m.txpassword + "caipiao");
                    int userid = dal.Add(m);
                    m.id = userid;
                    AddQuanXian(m);  //判断权限的
                    return Json(new { code = 0, msg = "新增成功！" });
                }
                else
                {
                    Model.Userinfo u = dal.GetModel(m.id);
                    if (u.password != m.password)
                    {
                        m.password = Tool.MD5Hash(m.username + m.password + "caipiao");
                    }
                    if (u.txpassword != m.txpassword)
                    {
                        m.txpassword = Tool.MD5Hash(m.username + m.txpassword + "caipiao");
                    }
                    m.parentid = parentid;
                    m.parentname = parentname;
                    m.parentpath = parentpath;
                    dal.Update(m);
                    AddQuanXian(m);  //判断权限的
                    return Json(new { code = 0, msg = "编辑成功！" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }

        /// <summary>
        /// 判断权限的，从权限表取出循环判断传有qxid_?过来没，有过来则说明授权，加入admin_quanxian表，但先判断是tj用户且添加的用户status in (0,2)才可添加，
        /// </summary>
        private void AddQuanXian(Model.Userinfo m)
        {
            Model.Userinfo admin = base.GetLoginAdmin();
            if (admin != null && admin.username == "tj")
            {
                if (m.status == 0 || m.status == 2)
                {
                    //添加权限前先把原先的都删除掉
                    admin_qxdal.DeleteByCond($"adminid={m.id}");

                    List<Model.Quanxian> list = qxdal.GetListArray("");
                    foreach (var item in list)
                    {
                        string key = $"qxid_{item.id}";
                        if (!string.IsNullOrEmpty(Request.Query[key]))
                        {
                            if (admin_qxdal.CalcCount($"qxid={item.id} and adminid={m.id}") == 0)
                            {
                                admin_qxdal.Add(new Model.Admin_quanxian()
                                {
                                    adminid = m.id,
                                    adminname = m.username,
                                    qxid = item.id,
                                    qxname = item.qxname,
                                });
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult Delete(string ids)
        {
            try
            {
                Model.Userinfo admin = base.GetLoginAdmin();
                int success = 0;
                string[] ss = ids.Split(',');
                foreach (var item in ss)
                {
                    int x;
                    if (int.TryParse(item, out x))
                    {
                        Model.Userinfo u = dal.GetModel(x);
                        if (u == null)
                        {
                            continue;
                        }
                        if (u.username == "aaa@qq.com")
                        {
                            continue; //顶级用户不可删除
                        }

                        czdal.DeleteByCond($"userid={u.id}");
                        lsdal.DeleteByCond($"userid={u.id}");
                        txdal.DeleteByCond($"userid={u.id}");
                        yudal.DeleteByCond($"userid={u.id}");
                        admin_qxdal.DeleteByCond($"adminid={u.id}");
                        xzdal.DeleteByCond($"userid={u.id}");

                        dal.Delete(x);
                        success++;

                        log.Info($"管理员【{u.username}】删除用户【{u.id} {u.username}】");
                    }
                }
                return Json(new { code = 0, msg = "成功删除" + success + "条记录！" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = $"出错：{ex.Message}" });
            }
        }


        //推荐图谱
        public ActionResult TJTuPu() { return View(); }

        //推荐图谱-取数据
        public ActionResult TJTuPu_Ajax(int? id)
        {
            ArrayList arr = new ArrayList();
            if (id == null)
            {
                //取顶级  
                List<Model.Userinfo> list_u = dal.GetListArray("parentid=0");
                foreach (var u in list_u)
                {
                    int xjcount = dal.CalcCount($"parentpath like '%,{u.id},%'");
                    string state = xjcount == 0 ? "open" : "closed";
                    Model.VM_1DayTongJi vm = xzdal.Get1DayTongJiModel(DateTime.Now, u.id);
                    arr.Add(new
                    {
                        id = u.id,
                        username = u.username,
                        regdate = u.createtime.ToString("yyyy-MM-dd"),
                        balance = u.balance,
                        today_tz = vm.zhong_je,
                        today_zj = vm.zhong_zjje,
                        xjcount = xjcount,
                        state = state,
                        op = $"<a target='_blank' href='/Adnn1n/TongJi/ShowMX_User?userid={u.id}&startdate={DateTime.Now.ToString("yyyy-MM-dd")}&enddate={DateTime.Now.ToString("yyyy-MM-dd")}'>详情</a>",
                    });
                }

            }
            else
            {
                //根据ID取下一级
                List<Model.Userinfo> list_u = dal.GetListArray($"parentid={id.Value}");
                foreach (var u in list_u)
                {
                    int xjcount = dal.CalcCount($"parentpath like '%,{u.id},%'");
                    string state = xjcount == 0 ? "open" : "closed";
                    Model.VM_1DayTongJi vm = xzdal.Get1DayTongJiModel(DateTime.Now, u.id);
                    arr.Add(new
                    {
                        id = u.id,
                        username = u.username,
                        regdate = u.createtime.ToString("yyyy-MM-dd"),
                        balance = u.balance,
                        today_tz = vm.zhong_je,
                        today_zj = vm.zhong_zjje,
                        xjcount = xjcount,
                        state = state,
                        op = $"<a  target='_blank' href='/Adnn1n/TongJi/ShowMX_User?userid={u.id}&startdate={DateTime.Now.ToString("yyyy-MM-dd")}&enddate={DateTime.Now.ToString("yyyy-MM-dd")}'>详情</a>",
                    });
                }

            }
            return Json(arr);
        }
    }
}
