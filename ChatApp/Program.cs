using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;
using ChatApp.Hubs;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebPWrecover.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    }).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "DENY");

    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

    //context.Response.Headers.Add("Content-Security-Policy",
    //     "default-src 'self'; " +
    //     "script-src 'self' https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/ https://your-signalr-hub-url; " +
    //     "style-src 'self' https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/ 'unsafe-inline'; " +
    //     "img-src 'self' data:; " +
    //     "connect-src 'self' wss://localhost:44310 http://localhost:53174 https://localhost:53174 ws://localhost:53174 wss://mishunini.hbo-ict.org http://mishunini.hbo-ict.org https://mishunini.hbo-ict.org ws://mishunini.hbo-ict.org; "
    //);
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string username = "Admin";
    string email = "admin@admin.com";
    string password = "Password(1234)";

    var roles = new[] { "Admin", "Moderator", "User" };
    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role)) await roleManager.CreateAsync(new IdentityRole(role));
    }

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.Id = new Guid().ToString();
        user.UserName = username;
        user.Email = email;
        user.Id = new Guid().ToString();
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
