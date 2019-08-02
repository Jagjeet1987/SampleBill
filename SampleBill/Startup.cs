using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleBill.Entity;
using SampleBill.Repository;
using SampleBill.Repository.Interfaces;
using SampleBill.Service;
using SampleBill.Service.Interface;
using SampleBill.Service.Mapping;

namespace SampleBill
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // ######### AutoMapper Configuration ################
            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<CommonMappingProfile>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            // ######### AutoMapper Configuration ################

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AccountingDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("CS_ConnectionString")));

            // ######### Services Configuration ################
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//You can set Time   
            });
            services.AddTransient<IJVoucherService, JVoucherService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<AccountingDbContext>().AllMigrationsApplied())
                    serviceScope.ServiceProvider.GetService<AccountingDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<AccountingDbContext>().EnsureSeeded();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
