using Domain.Entities;
using MongoDB.Driver;

namespace Infraestructure.Data;

public class LivroContext : ILivroContext
{
    private readonly IMongoDatabase _database;
    public IMongoCollection<Livro> Livros { get; }

    public LivroContext(string mongoConnectionString,
                        string mongoDatabaseName,
                        string mongoCollectionName)
    {
        MongoConnectionString = mongoConnectionString;
        MongoDatabaseName = mongoDatabaseName;
        MongoCollectionName = mongoCollectionName;

        var client = new MongoClient(MongoConnectionString);
        _database = client.GetDatabase(MongoDatabaseName);
        Livros = _database.GetCollection<Livro>(MongoCollectionName);
    }

    public string MongoConnectionString { get; }
    public string MongoDatabaseName { get; }
    public string MongoCollectionName { get; }
}