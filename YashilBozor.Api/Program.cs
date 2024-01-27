using YashilBozor.API.Configurations;
using YashilBozor.Service.Helpers;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();

WebHostEnviromentHelper.WebRootPath = Path.GetFullPath("wwwroot");

await app.ConfigureAsync();

await app.RunAsync();