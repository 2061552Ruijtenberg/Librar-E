using LibraryCollectionWebApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryCollectionWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LibraryWebAppContext>(DbContextOptions => DbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

            //Add Quote API
            builder.Services.AddHttpClient(name: "quotes-Api", configureClient: options =>
            {
                options.BaseAddress = new Uri("https://quotel-quotes.p.rapidapi.com/quotes/random");
            });

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("nl-NL")
            });

            app.Run();
        }
    }
}