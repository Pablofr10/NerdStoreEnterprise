using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcConfiguration();

var app = builder.Build();

app.UseApiConfiguration();

app.Run();
