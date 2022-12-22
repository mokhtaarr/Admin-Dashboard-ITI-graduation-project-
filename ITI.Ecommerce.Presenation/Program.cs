
﻿using ITI.Ecommerce.Models;
using ITI.Ecommerce.Services;
using JsonBasedLocalization.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ITI.Ecommerce.Presenation
{
    public class Program
    {
        public static int Main()

        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(@"Data Source=DESKTOP-AD4AI73\MSSQLSERVER01;initial catalog = ITI.EcommerceDB; integrated security = true;");
            });
         


            builder.Services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

  

            builder.Services.AddControllersWithViews();

            builder.Services.AddLocalization();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(JsonStringLocalizerFactory));
                });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]{ new CultureInfo("en-US"), new CultureInfo("ar-EG")};
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductImageService, ProductImageService>();
  
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<ICategoryServie, CategoryService>();
           
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters = string.Empty;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });


            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/SignIn";

                options.AccessDeniedPath = "/User/SignIn";
            });

            var app = builder.Build();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/Content",
                FileProvider = new PhysicalFileProvider
                (Path.Combine(Directory.GetCurrentDirectory(),
                "Content"))
            });

            app.UseAuthentication();
            app.UseAuthorization();
            var supportedCultures = new[] { "en-US", "ar-EG" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.MapControllerRoute("main", "{controller=Home}/{action=index}");

            app.Run();

            return 0;
        }
    }
}