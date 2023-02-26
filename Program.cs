using CS451R_Fundraiser.Data;
using Microsoft.EntityFrameworkCore;
using CS451R_Fundraiser.Models;
using CS451R_Fundraiser;
//using CS451R_Fundraiser.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CS451R_FundraiserContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("CS451R_FundraiserContext")));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SeedData.Initialize(services);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.Seed();
app.Run();