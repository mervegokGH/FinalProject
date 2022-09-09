using FinalProject.Application.Services.Concretes;
using FinalProject.Application.Services.Interfaces;
using FinalProject.Application.Services.PaximumServices.Concretes;
using FinalProject.Application.Services.PaximumServices.Interfaces;
using FinalProject.Data;
using FinalProject.Data.Repositories.Concretes;
using FinalProject.Data.Repositories.Interfaces;
using FinalProject.Shared.PaximumModels;
using FinalProject.Shared.SettingsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<MainDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.Configure<AuthenticationRequest>(Configuration.GetSection("PaximumLogin"));
            
            services.AddScoped<IPaximumService, PaximumService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBeginTransactionService, BeginTransactionService>();
            services.AddScoped<ICommitTransactionService, CommitTransactionService>();
            services.AddScoped<IGetArrivalAutoCompleteService, GetArrivalAutoCompleteService>();
            services.AddScoped<IGetProductInfoService, GetProductInfoService>();
            services.AddScoped<IPriceSearchService, PriceSearchService>();
            services.AddScoped<ISetReservationInfoService, SetReservationInfoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
