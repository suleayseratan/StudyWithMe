using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using StudyWithMe.Business.Abstract;
using StudyWithMe.Business.Concrete;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.DataAccess.Concrete.EfCore;
using StudyWithMe.WebUI.EmailServices;
using StudyWithMe.WebUI.Identity;

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
            // StudyWithMeContext 
            services.AddDbContext<StudyWithMeContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            
            // ApplicationContext
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
           // USer sınıfındaki özellikelri de kullanabilmek için tanımlama bu şekilde yapılmaldıır 
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout --> Kullanıcı hesabı kilitleme durumlarının ayarlanması
                options.Lockout.MaxFailedAccessAttempts = 5; // En fazla 5 kere yanliş şifre girişi
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Kilitlendikten 5 dakika sonra tekrar giriş yapabilir
                options.Lockout.AllowedForNewUsers = true; // Lockout'un aktif olamsı için kullanılır.

                // user
                // options.User.AllowedUserNameCharacters = ""; --> kullanıcının şifresinin nelerden oluşup oluşmayacağına akrar vermek için kullanılır.
                options.User.RequireUniqueEmail = true; // Her kullanıcının bir tane mail adresi olmalıdır.
                options.SignIn.RequireConfirmedEmail = true; // Kullancı giriş yapabilmesi için mail adresinin onaylı olamsı gerekir.
            });

            services.ConfigureApplicationCookie(options => {
                // Cookie ayarları
                // Server tarafının bizi tanıması için kullanılan bir yapıdır.
                options.LoginPath = "/account/login"; // cookie ile server tarafının bağlantısı herhangi bir sebeple koptuğunda login ekraanına gidilir
                options.LogoutPath = "/account/logout"; // logout yağıldığında cookielerin silinmesi gerekir.
                options.AccessDeniedPath = "/account/accessdenied"; // Kullanıcının erişiminin engellendiği sayfaya giriş yapmak istediğinde bu sayfa gösterilmelidir.
                options.SlidingExpiration = true; // Uygulamada istek yapılmadığında 20 dakikada cookie silinecektir ancak her bir istek yağıldığında 20 dakikanın yenilenmesi için true şeklinde işaretlenir.
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // Expiretion süresini ayarlamak için kullanılır
                options.Cookie = new CookieBuilder{
                    HttpOnly = true, // Http talebiyle cookie kullanılır.
                    Name = ".StudyWithMe.Security.Cookie", // Cookie ismi default olarak verilir fakat bu özellik ile cookie'nin adını değiştirebilriz.
                    SameSite = SameSiteMode.Strict, // cross site ataklarını engellemek için kullanılır
                };
            });
            
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            
            services.AddScoped<IEmailSender,SmtpEmailSender>(i =>
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"])
            );
            
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

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"settings",
                    pattern : "settings",
                    defaults : new {controller="Settings",Action="Setting"}
                );

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
