using CS451R_Fundraiser.Data;
using Microsoft.EntityFrameworkCore;
using CS451R_Fundraiser.Models;
using CS451R_Fundraiser;
using Microsoft.AspNetCore.Identity;
using MyApplication;
//using CS451R_Fundraiser.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CS451R_FundraiserContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("CS451R_FundraiserContext")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<CS451R_FundraiserContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.Seed();
app.Run();