using Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;

public static class DependencyInjection
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ILivroContext>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var mongoSettings = configuration.GetSection("MongoDbSettings");

            if (!mongoSettings.Exists() ||
                string.IsNullOrWhiteSpace(mongoSettings["ConnectionString"]) ||
                string.IsNullOrWhiteSpace(mongoSettings["DatabaseName"]) ||
                string.IsNullOrWhiteSpace(mongoSettings["CollectionName"]))
            {
                throw new InvalidOperationException("As configurações do MongoDB (ConnectionString, DatabaseName, CollectionName) devem ser fornecidas em 'MongoDbSettings'.");
            }

            return new LivroContext(
                mongoSettings["ConnectionString"],
                mongoSettings["DatabaseName"],
                mongoSettings["CollectionName"]
            );
        });
    }
}