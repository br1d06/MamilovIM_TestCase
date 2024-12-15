using Microsoft.EntityFrameworkCore;
using Teledok.DAL;
using Teledok.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql().
	AddDbContext<ApiDbContext>(options => options.UseNpgsql
	(builder.Configuration.GetConnectionString("PostgresDbConnection")));
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<FounderRepository>();
builder.Services.AddTransient<ClientService>();
builder.Services.AddTransient<FounderService>();
builder.Services.AddSwaggerGen();

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
app.UseSwagger();

app.UseRouting();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
