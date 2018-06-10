using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Niunan.CaiPiao.Web
{
    public class Startup
    {
        //log4net日志
        public static ILoggerRepository repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            //加载log4net日志配置文件
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //取出appsetting.json中的数据库连接字符串
            string connStr = Configuration.GetSection("ConnStr").Value;

            //注入
            services.AddSingleton<Util.VierificationCodeServices>(new Util.VierificationCodeServices());
            services.AddSingleton<DAL.CaizhongDAL>(new DAL.CaizhongDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.EmailsetDAL>(new DAL.EmailsetDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.UserinfoDAL>(new DAL.UserinfoDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.LiushuiDAL>(new DAL.LiushuiDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.ChongzhiDAL>(new DAL.ChongzhiDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.TixianDAL>(new DAL.TixianDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.YugengdanDAL>(new DAL.YugengdanDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.QuanxianDAL>(new DAL.QuanxianDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.XiazhuinfoDAL>(new DAL.XiazhuinfoDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.Admin_quanxianDAL>(new DAL.Admin_quanxianDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.CategoryDAL>(new DAL.CategoryDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.NewsDAL>(new DAL.NewsDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.WanfaDAL>(new DAL.WanfaDAL() { ConnStr = connStr });
            services.AddSingleton<DAL.UserbankDAL>(new DAL.UserbankDAL() { ConnStr = connStr });
            services.AddSingleton<BLL.BeiJing28>(new BLL.BeiJing28() { ConnStr = connStr });
            services.AddSingleton<BLL.BJPK10>(new BLL.BJPK10() { ConnStr = connStr });

            //添加gb2312的支持
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //添加session支持，记得先在nuget中搜索session装上
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
          name: "areas",
          template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
            });
        }
    }
}
