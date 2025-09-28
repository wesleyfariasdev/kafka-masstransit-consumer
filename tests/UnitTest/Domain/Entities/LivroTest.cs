using Domain.Entites;
using Domain.Enums;

namespace UnitTest.Domain.Entities;

public class LivroTest
{
    private readonly Livro _livroComum;

    public LivroTest()
    {
        _livroComum = new Livro("1984", "George Orwell", "978-0-452-28423-4", 1949, Status.Lendo);
    }


    [Fact(DisplayName = "Cria livro com valores validos")]
    [Trait("Domain", "Livro")]
    public void DeveCriarLivroComDadosValidos()
    {
        // Arrange
        var titulo = "O Senhor dos Anéis";
        var autor = "J.R.R. Tolkien";
        var isbn = "978-3-16-148410-0";
        var anoPublicacao = 1954;

        // Act
        var livro = new Livro(titulo, autor, isbn, anoPublicacao, Status.Lendo);
        // Assert
        Assert.Equal(titulo, livro.Titulo);
        Assert.Equal(autor, livro.Autor);
        Assert.Equal(isbn, livro.ISBN);
        Assert.Equal(anoPublicacao, livro.AnoPublicacao);
    }

    [Fact(DisplayName = "Deve alterar status do livro para Lido")]
    [Trait("Domain", "Livro")]
    public void DeveAlterarStatusParaLido()
    {
        // Act
        _livroComum.MarcarComoLido();

        // Assert
        Assert.Equal(Status.Lido, _livroComum.Status);
    }

    [Fact(DisplayName = "Deve conter Id preenchido")]
    [Trait("Domain", "Livro")]
    public void DeveConterIdPreenchido()
    {
        Assert.True(!string.IsNullOrWhiteSpace(_livroComum.Id));
    }

    [Fact(DisplayName = "Deve alterar status do livro para Quero Ler")]
    [Trait("Domain", "Livro")]
    public void DeveAlterarStatusParaQueroLer()
    {
        // Act
        _livroComum.MarcarComoQueroLer();

        // Assert
        Assert.Equal(Status.QueroLer, _livroComum.Status);
    }


    [Fact(DisplayName = "Deve alterar status do livro para Quero Ler")]
    [Trait("Domain", "Livro")]
    public void DeveAlterarStatusParaLendo()
    {
        // Act
        _livroComum.MarcarComoLendo();

        // Assert
        Assert.Equal(Status.Lendo, _livroComum.Status);
    }
}
