using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

/// <summary>
/// 命名空间
/// </summary>
namespace cn.test.web
{
    /// <summary>
    /// Starup
    /// </summary>
    public class Startup
    {
        static string[] docs = { "none", "Test" };

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IWebHostEnvironment Env { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        /// <summary>
        /// 环境
        /// </summary>
        /// <param name="environment"></param>
        public Startup(IWebHostEnvironment environment)
        {
            Env = environment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();相等于如下：
            services.AddControllers();
            //services.AddControllersWithViews();
            services.AddRazorPages();
            if (Env.IsDevelopment())
            {
                services.AddSwaggerGen(opt =>
                {
                    opt.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Api",
                        Version = "v1"
                    });

                    opt.DocInclusionPredicate((docName, description) => true);
                    //opt.CustomSchemaIds(d => d.FullName);
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                .UseSwaggerUI(opt =>
                    {
                        opt.SwaggerEndpoint($"/swagger/v1/swagger.json", "Api V1");
                    });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                // endpoints.MapControllerRoute(
                //     name: "ParamsMappingTest",
                //     pattern: "pmt/{action}/{id?}",
                //     defaults: new { controller = "ParamsMappingTest" }
                //     );
            });
        }
    }
}
