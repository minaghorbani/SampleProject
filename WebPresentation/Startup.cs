using Application.BlogApplication;
using Application.BlogApplication.Command.Create;
using Application.BlogApplication.Queries.FindById;
using Application.BlogApplication.Queries.GetAll;
using Application.CategoryApplication;
using Application.Common;
using Application.OrderApplication;
using Application.TagApplication;
using AspNetCoreRateLimit;
using Autofac;
using Domain.Identity;
using Helpers.Email;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebPresentation.Models;
//using WebPresentation.Data;

namespace WebPresentation
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
            //configure EF
            services.AddDbContext<SiteDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));

            //Configure Identity 
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SiteDbContext>()
            .AddDefaultTokenProviders()
           .AddDefaultUI();


            services.AddDatabaseDeveloperPageExceptionFilter();

            //JWT
            services.AddAuthentication(option =>
            {
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuer = Configuration["BearerTokens:Issuer"],
                        ValidateIssuer = false,
                        ValidAudience = Configuration["BearerTokens:Audience"],
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"])),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.Configure<IdentityOptions>(option =>
            {

            });

            //identity configuration
            services.Configure<CookieAuthenticationOptions>(option =>
            {
                option.ExpireTimeSpan = TimeSpan.FromDays(1);
                option.Cookie.Expiration = TimeSpan.FromDays(2);
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
                option.AddPolicy("TehranOnly", policy => policy.RequireClaim("City", "Tehran"));
            });
            services.AddMvc().AddRazorPagesOptions(option =>
            {
                option.Conventions.AuthorizeAreaFolder("User", "/");
                option.Conventions.AuthorizeAreaFolder("Admin", "/", "RequireAdminRole");
            });

            services.AddHttpContextAccessor();

            //Email
            services.AddTransient<IEmailSender, EmailSender>();

            //AutoMapper
            services.AddAutoMapper(typeof(Mappers).GetTypeInfo().Assembly);

            //Dependency injection
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));

            services.AddScoped<ITagService, TagService>();
            services.AddScoped(typeof(ITagRepository), typeof(TagRepository));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(typeof(IOrdersRepository), typeof(OrdersRepository));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //Add MediatR DI
            services.AddMediatR(typeof(BlogCreateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(FindBlogsByIdQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllBlogsQuery).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<BlogCreateCommand, int>), typeof(BlogCreateValidationBehavior<BlogCreateCommand, int>));


            //services.AddControllers().AddNewtonsoftJson();
            // For Upload file
            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            //Setting Up Rate Limiting 

            // needed to load configuration from appsettings.json 
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            //check
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));


            // inject counter and rules stores
            services.AddInMemoryRateLimiting();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseIpRateLimiting();

            var logger = loggerFactory.CreateLogger("testLog");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AreaDefault",
                    areaName: "blog",
                    pattern: "blog/{controller=Blogs}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabaseOptions(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), ConfigureSqlServerDatabaseOptions);
        }

        private void ConfigureSqlServerDatabaseOptions(SqlServerDbContextOptionsBuilder builder)
        {
            builder.MigrationsAssembly(typeof(SiteDbContext).Namespace);
        }


    }
}
