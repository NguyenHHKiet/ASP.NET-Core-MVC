using Microsoft.EntityFrameworkCore;
using TicketsForMovies.Data;
using TicketsForMovies.Data.Services.Actors;
using TicketsForMovies.Data.Services.Producers;

/*
 * Builder
 */

var builder = WebApplication.CreateBuilder(args);

/*
 * Add services to the container.
 */
/*
 * DbContext configuration
 * DbContext is typically registered and managed via dependency injection.
 */
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

// Services configuration
builder.Services.AddScoped<IActorsServices, ActorsServices>();
builder.Services.AddScoped<IProducersServices, ProducersServices>();

builder.Services.AddControllersWithViews();

/*
 * App
 */

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

AppDbInitializer.Seed(app);

app.Run();
