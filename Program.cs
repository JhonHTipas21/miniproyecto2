using System;
using GestorGastos.Web.Data;
using GestorGastos.Web.Models;
using GestorGastos.Web.Repositories;
using GestorGastos.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 0) EF Core Developer exception filter — muestra errores de BD en dev
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// 1) EF Core + MySQL (Pomelo)
//    Ajusta la versión de MySQL si cambias de servidor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    )
);

// 2) Identity con ApplicationUser
builder.Services
    .AddDefaultIdentity<ApplicationUser>(opts =>
    {
        opts.SignIn.RequireConfirmedAccount = false;
        // Aquí podrías afinar políticas de contraseña, lockout, etc.
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 3) MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// 4) Repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IGastoRepository, GastoRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();

// 5) Servicios de negocio
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<GastoService>();
builder.Services.AddScoped<EntradaService>();

var app = builder.Build();

// 6) Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // Detalle de excepciones + endpoint para migraciones
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// 7) Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.Run();
