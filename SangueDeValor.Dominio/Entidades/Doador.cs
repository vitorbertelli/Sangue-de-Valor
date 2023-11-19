using SangueDeValor.Dominio.Enumeradores;
using System.Text.RegularExpressions;

namespace SangueDeValor.Dominio.Entidades;

public class Doador
{
    public int Id { get; private set; }
    public string NomeCompleto { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public TipoSanguineo TipoSanguineo { get; private set; }
    public decimal Peso { get; private set; }
    public DateTime? UltimaDoacao { get; private set; }
    public int? Pontos { get; private set; }
    public string? Imagem { get; private set; }

    public Doador(string nomeCompleto, string email, string senha, TipoSanguineo tipoSanguineo, decimal peso)
    {
        SetNomeCompleto(nomeCompleto);
        SetEmail(email);
        SetSenha(senha);
        SetTipoSanguineo(tipoSanguineo);
        SetPeso(peso);
    }

    public Doador(int id, string nomeCompleto, string email, string senha, TipoSanguineo tipoSanguineo, decimal peso, DateTime ultimaDoacao, int pontos, string imagem)
    {
        if (id < 0)
        {
            throw new Exception("");
        }
        Id = id;
        UltimaDoacao = ultimaDoacao;
        Pontos = pontos;
        Imagem = imagem;
        SetNomeCompleto(nomeCompleto);
        SetEmail(email);
        SetSenha(senha);
        SetTipoSanguineo(tipoSanguineo);
        SetPeso(peso);
    }

    public void SetNomeCompleto(string nomeCompleto)
    {
        if (string.IsNullOrEmpty(nomeCompleto) || string.IsNullOrWhiteSpace(nomeCompleto))
        {
            throw new Exception("");
        }

        if (nomeCompleto.Length > 100)
        {
            throw new Exception("");
        }

        NomeCompleto = nomeCompleto;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("");
        }

        if (email.Length > 250)
        {
            throw new Exception("");
        }

        string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        if (!Regex.IsMatch(email, emailPattern))
        {
            throw new Exception("");
        }

        Email = email;
    }

    public void SetSenha(string senha)
    {
        if (string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
        {
            throw new Exception("");
        }

        if (senha.Length > 250)
        {
            throw new Exception("");
        }

        Senha = senha;
    }

    public  void SetSenhaHash(string senhaHash)
    {
        Senha = senhaHash;
    }

    public void SetTipoSanguineo(TipoSanguineo tipoSanguineo)
    {
        if (!Enum.IsDefined(tipoSanguineo))
        {
            throw new Exception("");
        }

        TipoSanguineo = tipoSanguineo;
    }

    public void SetPeso(decimal peso)
    {
        if (peso < 0)
        {
            throw new Exception("");
        }

        Peso = peso;
    }
}
