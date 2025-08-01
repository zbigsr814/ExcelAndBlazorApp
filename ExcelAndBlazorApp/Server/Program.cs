using ExcelAndBlazorApp.Entities;
using ExcelAndBlazorApp.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<CompanySeeder>();
builder.Services.AddAutoMapper(typeof(MappingProfile));     // skanuje automatycznie wszystkie profile w projekcie

builder.Services.AddDbContext<CompanyDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("Company")));

var app = builder.Build();

// Seedowanie danych przy starcie aplikacji
using (var scope = app.Services.CreateScope())
{
	var seeder = scope.ServiceProvider.GetRequiredService<CompanySeeder>();
	seeder.Seed(); // Wywo³anie metody seeduj¹cej dane
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
