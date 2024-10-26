using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";  
        options.LogoutPath = "/Auth/Logout"; 
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();  
app.UseAuthorization();   

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "movieDetails",
        pattern: "movies/{id:int}", 
        defaults: new { controller = "Home", action = "MovieDetail" });

    endpoints.MapControllerRoute(
        name: "tvShowDetails",
        pattern: "tvshows/{id:int}", 
        defaults: new { controller = "Home", action = "TVShowDetail" });

    endpoints.MapControllerRoute(
        name: "addComment",
        pattern: "Comment/AddComment",
        defaults: new { controller = "Comment", action = "AddComment" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
