using NSE.Identidade.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;
builder.Services.IdentityDependency(_configuration.GetSection("AppSettings"));
builder.Services.ConfiguracoesApi(_configuration.GetConnectionString("DefaultConnectionString"));

var app = builder.Build();

app.UseApiConfiguration();
