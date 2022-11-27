using Microsoft.EntityFrameworkCore;
using projContato.Data;
using projContato.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// configura o Banco de dados com DbContext
builder.Services.AddDbContext<BancoContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));


// Injetando a interface do Repositorio
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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
