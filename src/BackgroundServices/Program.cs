using BackgrondServices;
using Infraestructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

DependencyInjection.RegisterServices(builder.Services);

var host = builder.Build();
host.Run();
