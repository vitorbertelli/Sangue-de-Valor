using System.Xml.Serialization;

namespace SangueDeValor.Dominio.Entidades;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public string Imagem { get; private set; }
    public int ParceiroId { get; private set; }
    public Parceiro Parceiro { get; private set; }

    public Produto(int id, int parceiroId, string nome, decimal preco, string imagem)
    {
        if (id < 0 || parceiroId < 0)
        {
            throw new Exception("");
        }
        Id = id;
        ParceiroId = parceiroId;
        SetNome(nome);
        SetPreco(preco);
        SetImagem(imagem);
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("");
        }

        if (nome.Length > 50)
        {
            throw new Exception("");
        }

        Nome = nome;
    }

    public void SetPreco(decimal preco)
    {
        if (preco < 0)
        {
            throw new Exception("");
        }
        Preco = preco;
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
