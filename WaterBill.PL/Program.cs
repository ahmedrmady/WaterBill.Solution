using Microsoft.EntityFrameworkCore;
using WaterBill.DAL.Data;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.Extenstions;

namespace WaterBill.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Confugre Services
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            

            //add DB Service 
            builder.Services.AddDbContext<AppDbContext>(Options => 
            Options.UseSqlServer(builder.Configuration
                   .GetConnectionString("DefualtConnection"))
            );

            //add Application Services 
            builder.Services.AddApplactionServices();

            #endregion

            var app = builder.Build();

            //Migrate DataBase and Seed data into DB

            #region Database Migration and Data Seeding
            var scope = app.Services.CreateScope();
          using  var _appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
          using  var _logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>(); ;

            try
            {
                //applay all unAplied Migrations
                await _appDbContext.Database.MigrateAsync();

                //seed data to DB
              await  DataSeeding.DataSeedAsync(_appDbContext, _logger);
            }
            catch (Exception)
            {

                throw;
            } 
            #endregion

            #region Confiugre MiddleWares
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

            #endregion
            app.Run();
        }
    }
}