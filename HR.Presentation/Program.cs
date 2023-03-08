using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using HR.Application.IoC;
using HR.Application.Validators;
using HR.Domain.Entities;
using HR.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UpdatePersonnelValidator>()).AddRazorRuntimeCompilation();


var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<HumanResourcesDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{ //identity options lar� verebilece�imiz bir overload yap�s� mevcut. Biz default ayalar� kullanmak istemeyip yap�land�rma yapmak istiyorsak belirtebiliriz. 

    opt.Password.RequireDigit = false;              //�ifremiz say� i�ermesine gerek yok
    opt.Password.RequiredLength = 1;               //gerekli uzunluk 1 e �ektik gibi d�zenlemeler yap�labilir.
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.SignIn.RequireConfirmedEmail = false;
   
    //Default olarak false gelir. SignInResult "IsNotAllowed" �zelli�i dir . Mail onaylamas�.
    opt.Lockout.MaxFailedAccessAttempts = 10;       //4 hatal� denemeden sonra hesab� kitle
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //Hesab� 5 dakika boyunca kitle dedik. 
    opt.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGHIJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";


}).AddEntityFrameworkStores<HumanResourcesDbContext>().AddDefaultTokenProviders();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
	builder.RegisterModule(new DependencyResolver());
});


builder.Services.ConfigureApplicationCookie(_ => _.LoginPath = "/Login/Login/");

builder.Services.AddSession(_ => _.IdleTimeout = TimeSpan.FromMinutes(30));
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

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
  name: "areas",
  pattern: "{area:exists}/{controller=Personnel}/{action=AddPersonnel}/{id?}"
);

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Personnel}/{action=Index}/{id?}"
);
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Admin}/{action=AdminProfile}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}");



app.Run();
