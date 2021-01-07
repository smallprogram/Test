using BlazorIdentityServer.Server.Data;
using BlazorIdentityServer.Server.Services;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorIdentityServer.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            var connectionString = Configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
             {
                 options.SignIn.RequireConfirmedAccount = true;
                 options.Password.RequireDigit = false;
                 options.Password.RequiredLength = 4;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;

             })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // EFǨ�����ݿ�ʱ��Ҫ�õ�����
            // ʹ��EF��Ǩ��ʱ�����PowerShell��������Package Manager Console��ִ����������Ǩ��
            // ���û��ȫ�ְ�װEFCore Tools���޷�ʹ��PowerShellִ��Ǩ�Ƶġ���Ҫִ���������
            // dotnet tool install --global dotnet-ef
            // ȷ�������а�װ��Microsoft.EntityFrameworkCore.Design,���û���밲װ�� dotnet add package Microsoft.EntityFrameworkCore.Design
            // ��ʼִ��Ǩ�ƣ�-o��ѡ����λ�ã�
            // dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
            // dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
            // dotnet ef migrations add InitialAspNetCoreIdentityDbMigration -c ApplicationDbContext -o Data/Migrations/IdentityServer/AspNetCoreIdentityDb
            // �������ݿ⣺
            // dotnet ef database update InitialAspNetCoreIdentityDbMigration -c ApplicationDbContext
            // dotnet ef database update InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext
            // dotnet ef database update InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(options =>
            {
                // ΪIdentityServer�����¼���¼��־
                // ������־
                options.Events.RaiseErrorEvents = true;
                // ʧ����־
                options.Events.RaiseFailureEvents = true;
                // ��Ϣ��־
                options.Events.RaiseInformationEvents = true;
                // �ɹ���־
                options.Events.RaiseSuccessEvents = true;


                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;  // ????

                // �Զ������URL
                options.UserInteraction = new UserInteractionOptions
                {
                    LogoutUrl = "/Account/Logout",
                    LoginUrl = "/Account/Login",
                    LoginReturnUrlParameter = "returnUrl"
                };
            })
                .AddAspNetIdentity<IdentityUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                })
                // ֤��
                .AddDeveloperSigningCredential();


            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                
            });
        }
    }
}
