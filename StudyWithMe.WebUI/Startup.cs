using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using StudyWithMe.Business.Abstract;
using StudyWithMe.Business.Concrete;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.DataAccess.Concrete.EfCore;

namespace studyWithMe.WebUI
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudyWithMeContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            
            services.AddControllersWithViews();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name:"streamvideos",
                    pattern : "streamvideos/{genre?}",
                    defaults : new {controller="Stream",Action="List"}
                );

                endpoints.MapControllerRoute(
                    name:"livevideos",
                    pattern : "livevideos/{genre?}",
                    defaults : new {controller="Live",Action="List"}
                );

                endpoints.MapControllerRoute(
                    name:"groups",
                    pattern : "groups/{genre?}",
                    defaults : new {controller="Group",Action="List"}
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
