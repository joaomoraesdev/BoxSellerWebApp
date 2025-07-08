using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;
using WebAppML.Bll;
using WebAppML.Database;
using WebAppML.Entity;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// ADICIONA o user-secrets apenas em ambiente de desenvolvimento
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Carregar configura��es do appsettings.json
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

// MongoClient singleton
builder.Services.AddSingleton<MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Banco de dados
builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    var client = sp.GetRequiredService<MongoClient>();
    return client.GetDatabase(settings.Database);
});

// Cole��es espec�ficas
builder.Services.AddSingleton<IMongoCollection<Aplicacao>>(sp =>
    sp.GetRequiredService<IMongoDatabase>().GetCollection<Aplicacao>("collection_aplicacao"));

// Servi�os
builder.Services.AddSingleton<AplicacaoBll>();

// Adiciona suporte a sess�es
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpClient();

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

// === ABRE A URL DO NGROK AO INICIAR ===
var ngrokUrl = "https://6246-177-161-241-125.ngrok-free.app"; // coloque sua URL do ngrok aqui
try
{
    Process.Start(new ProcessStartInfo
    {
        FileName = ngrokUrl,
        UseShellExecute = true // necess�rio para abrir com o navegador padr�o
    });
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao abrir navegador: {ex.Message}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Index}/{id?}");

app.Run();
