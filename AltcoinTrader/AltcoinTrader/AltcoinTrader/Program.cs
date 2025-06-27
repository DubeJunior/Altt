using AltcoinTrader.Data;
using AltcoinTrader.Service;
using Microsoft.EntityFrameworkCore;

namespace AltcoinTrader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDBcontext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<CoinService>();
           
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Coin}/{action=CoinForm}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}