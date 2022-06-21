using Dotnet7SignalRSample.Data;
using Dotnet7SignalRSample.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var connectionAzureSignalR = "Endpoint=https://dotnet7signalrsample.service.signalr.net;AccessKey=ly5GeVNTtX8HrP/058FRc1LI+mSjAkrvQt9YjhY7JN0=;Version=1.0;";

builder.Services.AddSignalR().AddAzureSignalR(connectionAzureSignalR);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<UserHub>("/hubs/userCount");
app.MapHub<DeathlyHallowsHub>("/hubs/deathyhallows");
app.MapHub<HouseGroupHub>("/hubs/houseGroup");
app.MapHub<NotificationHub>("/hubs/notification");
app.MapHub<BasicChatHub>("/hubs/basicchat");
app.MapHub<ChatHub>("/hubs/chat");
app.MapHub<OrderHub>("/hubs/order");



app.Run();
