using Domain.Entities;
using Domain.Enums;
using Infraestructure.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace UnitTest.Infrastructure.Data;

public class LivroContextTests
{
    [Fact(DisplayName = "Adiciona livro no MongoDB via contexto")]
    [Trait("Infrastructure", "LivroContext")]
    public async Task DeveAdicionarLivroNoMongoDB()
    {
        // Arrange
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "MongoDbSettings:ConnectionString", "mongodb://localhost:27017" },
                { "MongoDbSettings:DatabaseName", "ConsumerServicesDb" },
                { "MongoDbSettings:CollectionName", "Livros" }
            })
            .Build();
        var context = new LivroContext(
            configuration["MongoDbSettings:ConnectionString"],
            configuration["MongoDbSettings:DatabaseName"],
            configuration["MongoDbSettings:CollectionName"]
        );
        var livro = new Livro
        (
            "1984",
            "George Orwell",
            "978-0-452-28423-4",
            1949,
            Status.Lendo
        );

        // Act
        await context.Livros.InsertOneAsync(livro);
        var livroSalvo = await context.Livros.Find(l => l.Id == livro.Id).FirstOrDefaultAsync();

        // Assert
        Assert.NotNull(livroSalvo);
        Assert.Equal(livro.Titulo, livroSalvo.Titulo);
        Assert.Equal(livro.Id, livroSalvo.Id);
    }
}