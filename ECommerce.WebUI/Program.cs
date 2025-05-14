

using Castle.Core.Smtp;
using ECommerce.Data;
using ECommerce.MyServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<database>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("costr")));
// Add services to the container.
builder.Services.AddControllersWithViews();

#region MyServices
builder.Services.AddRazorPages();

builder.Services.AddMyServices(builder.Configuration);

builder.Services.AddTransient<IEmailSender, EmailSenderConfirm>();


#endregion


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapRazorPages();
app.Run();