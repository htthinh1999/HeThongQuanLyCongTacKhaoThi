using FluentValidation.AspNetCore;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Classes;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.ExamDetails;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.ScoreTypes;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswerDetails;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.Application.System.Accounts;
using HeThongQuanLyCongTacKhaoThi.Application.System.Roles;
using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI
{
    public class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory =
        LoggerFactory.Create(
            builder =>
            {
                builder.AddConsole()
                       .AddFilter(level => level == LogLevel.Information);
            }
        );

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HeThongQuanLyCongTacKhaoThiDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MAIN_CONNECTION_STRING))
                            .UseLoggerFactory(MyLoggerFactory)
                            .EnableSensitiveDataLogging());

            // Add Identity
            services.AddIdentity<Account, Role>()
                .AddEntityFrameworkStores<HeThongQuanLyCongTacKhaoThiDbContext>()
                .AddDefaultTokenProviders();

            // Declare DI
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<UserManager<Account>, UserManager<Account>>();
            services.AddTransient<SignInManager<Account>, SignInManager<Account>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IQuestionGroupService, QuestionGroupService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IExamDetailService, ExamDetailService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IStudentAnswerService, StudentAnswerService>();
            services.AddTransient<IStudentAnswerDetailService, StudentAnswerDetailService>();
            services.AddTransient<IContestService, ContestService>();
            services.AddTransient<IScoreTypeService, ScoreTypeService>();
            services.AddTransient<IResultService, ResultService>();

            // Declare Fluent Validator
            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();

            //services.AddControllersWithViews();
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            // Declare Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger HeThongQuanLyCongTacKhaoThi Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using Bear scheme. Example: Bearer 'token'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            // Add authorize
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(5),    // recommend 5 minutes or less
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.All,
                     policy => policy.RequireRole(Roles.Admin, Roles.Teacher, Roles.Student));
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
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger HeThongQuanLyCongTacKhaoThi Solution V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}