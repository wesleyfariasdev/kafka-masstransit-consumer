using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public sealed class Livro
{
    public Livro(string titulo, string autor, string iSBN, int anoPublicacao, Status status)
    {
        Id = ObjectId.GenerateNewId().ToString();
        Titulo = titulo;
        Autor = autor;
        ISBN = iSBN;
        AnoPublicacao = anoPublicacao;
        Status = status;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("titulo_livro")]
    public string Titulo { get; set; }
    [BsonElement("autor")]
    public string Autor { get; set; }
    [BsonElement("isbn")]
    public string ISBN { get; set; }
    [BsonElement("ano_publicacao")]
    public int AnoPublicacao { get; set; }
    [BsonElement("status")]
    public Status Status { get; set; }

    public void MarcarComoLido() =>
           Status = Status.Lido;

    public void MarcarComoLendo() =>
           Status = Status.Lendo;

    public void MarcarComoQueroLer() =>
           Status = Status.QueroLer;
}
