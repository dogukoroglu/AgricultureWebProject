using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureWebProject
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
			//-----------------------------Controllers----------------------------------
			services.AddScoped<IServiceService,ServiceManager>();
			services.AddScoped<IServiceDal,EfServiceDal>();

			services.AddScoped<ITeamService, TeamManager>();
			services.AddScoped<ITeamDal, EfTeamDal>();

			services.AddScoped<IAnnouncementService, AnnouncementManager>();
			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

			services.AddScoped<IImageService, ImageManager>();
			services.AddScoped<IImageDal, EfImageDal>();

			services.AddScoped<IAddressService, AddressManager>();
			services.AddScoped<IAddressDal, EfAddressDal>();

			//---------------------------------------------------------------


			//------------------------------Validators------------------------
			services.AddScoped<IValidator<Team>, TeamValidator>();
			services.AddScoped<IValidator<Announcement>, AnnouncementValidator>();
			services.AddScoped<IValidator<Service>, ServiceValidator>();
			services.AddScoped<IValidator<Image>, ImageValidator>();
			services.AddScoped<IValidator<Address>, AddressValidator>();
			//---------------------------------------------------------------


			services.AddDbContext<AgricultereContext>();
			services.AddControllersWithViews();
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
