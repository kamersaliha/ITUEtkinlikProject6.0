using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using ITUEtkinlikProject6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ITUEtkinlikProject6._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<Context>();
			builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
            builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

            builder.Services.AddSingleton<IYayinTalebiService, YayinTalebiManager>();
            builder.Services.AddSingleton<IYayinTalebiDal, EfYayinTalebiDal>();

            //builder.Services.AddSingleton<IKampusService, YayinTalebiManager>(); //Buranýn hata vermesinin sebebi IKampusService'dan inherit almamasý !!
            builder.Services.AddSingleton<IKampusService, KampusManager>();
            builder.Services.AddSingleton<IKampusDal, EfKampusDal>();

            builder.Services.AddSingleton<IKategoriService, KategoriManager>();
            builder.Services.AddSingleton<IKategoriDal, EfKategoriDal>();

            builder.Services.AddSingleton<ISalonService, SalonManager>();
            builder.Services.AddSingleton<ISalonDal, EfSalonDal>();

            builder.Services.AddSingleton<IEtkinlikService, EtkinlikManager>();
            builder.Services.AddSingleton<IEtkinlikDal, EfEtkinlikDal>();

            builder.Services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});

			builder.Services.AddMvc();
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}