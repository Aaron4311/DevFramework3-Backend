using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevFramework.Core.DependencyResolvers;
using DevFramework.Core.Extensions;
using DevFramework.Core.Utilities.IoC;
using DevFramework.Northwind.Business.DependencyResolvers.Autofac;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacBusinessModule());
	});
builder.Services.AddDependencyResolvers(new ICoreModule[]
			{
				new CoreModule()
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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();