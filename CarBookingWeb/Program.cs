using CarBookingRepository.Contract;
using CarBookingRepository.Implementation;
using CarBookingWeb.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarBookingWeb.Areas.Identity.Data;
using CarBookingDataModify.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using CarBookingUtility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<CarBookingWebContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("CarBookingWebContext") ?? throw new InvalidOperationException("Connection string 'CarBookingWebContext' not found.")));

// Custom - Register ConnectionString and DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationCS"));
});

//Auto generated
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//Custom - For Identity
//builder.Services.AddIdentityCore<IdentityUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//Modify Identity configuration after including Identity in project
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//}).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//}).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddDefaultTokenProviders().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//Custom - Register fake implementation of IEmailSender
builder.Services.AddSingleton<IEmailSender, EmailSender>();

// Custom - Register IGenericRepostiory and GenericRepository, Repository Pattern
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

//Custom - Add Authorization attribute globally (on each page)
builder.Services.AddRazorPages(x =>
{
    x.Conventions.AuthorizeFolder("/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Custom - For Login
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
