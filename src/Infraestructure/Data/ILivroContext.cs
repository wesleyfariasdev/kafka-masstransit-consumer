using Domain.Entities;
using MongoDB.Driver;

namespace Infraestructure.Data;

internal interface ILivroContext
{
    IMongoCollection<Livro> Livros { get; }
}
