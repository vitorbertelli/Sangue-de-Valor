using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace SangueDeValor.Dominio.Entidades;

public class Parceiro
{
    public int Id { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Imagem { get; private set; }
    public int CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; }
    public IEnumerable<Produto> Produtos { get; private set; }

    public Parceiro(int id, int categoriaId, string nomeFantasia, string imagem)
    {
        if (id < 0 || categoriaId < 0)
        {
            throw new Exception("");
        }
        Id = id;
        CategoriaId = categoriaId;
        SetNomeFantasia(nomeFantasia);
        SetImagem(imagem);
    }

    public void SetNomeFantasia(string nome)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("");
        }

        if (nome.Length > 50)
        {
            throw new Exception("");
        }

        NomeFantasia = nome;
    }

    public void SetImagem(string imagem)
    {
        if (string.IsNullOrEmpty(imagem) || string.IsNullOrWhiteSpace(imagem))
        {
            throw new Exception("");
        }

        if (imagem.Length > 250)
        {
            throw new Exception("");
        }

        Imagem = imagem;
    }
}
