using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zamawianie_biletow;
using Zamawianie_biletow.Models;
using Zamawianie_biletow.Services;
using Zamawianie_biletow.Services.Interfaces;

internal class Program
{
    private static async Task Main(string[] args) //wczesniej zamiast task by³ void 24.01.2024
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IWarehouseService, WarehouseServices>();

        builder.Services.AddDbContext<DbTicket>(builder =>
        {
            builder.UseSqlServer(@"Data Source=WWO\SQLEXPRESS;Initial Catalog=DbTicket;Integrated Security=True;Trust Server Certificate=True");
        });

        builder.Services.AddIdentity<UserModel, IdentityRole>(option =>
        {
            option.Password.RequireDigit = false;
            option.Password.RequiredLength = 2;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireLowercase = false;
        }).AddEntityFrameworkStores<DbTicket>();
        


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

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope()) //dodane na dzieñ 24.01.2024
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        app.Run();
    }
}