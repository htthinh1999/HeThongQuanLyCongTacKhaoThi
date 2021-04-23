using FluentValidation.AspNetCore;
using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    //options.AccessDeniedPath = "/Account/Forbiden";
                });

            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddSession(option => option.IdleTimeout = TimeSpan.FromHours(2));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IAccountApiClient, AccountApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();
            services.AddTransient<IQuestionApiClient, QuestionApiClient>();
            services.AddTransient<IQuestionGroupApiClient, QuestionGroupApiClient>();
            services.AddTransient<IAnswerApiClient, AnswerApiClient>();
            services.AddTransient<IExamApiClient, ExamApiClient>();
            services.AddTransient<ISubjectApiClient, SubjectApiClient>();
            services.AddTransient<IContestApiClient, ContestApiClient>();
            services.AddTransient<IScoreTypeApiClient, ScoreTypeApiClient>();

            IMvcBuilder builder = services.AddRazorPages();
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            builder.AddRazorRuntimeCompilation();
#if DEBUG
            if (enviroment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
# endif
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.Manager,
                     policy => policy.RequireRole(Roles.Admin, Roles.Teacher));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "images")),
                RequestPath = "/images"
            });

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}