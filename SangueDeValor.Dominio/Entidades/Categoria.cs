namespace SangueDeValor.Dominio.Entidades;

public class Categoria
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public IEnumerable<Parceiro> Parceiros { get; private set; }

    public Categoria(int id, string nome)
    {
        if (id < 0)
        {
            throw new Exception("");
        }
        Id = id;
        SetNome(nome);
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
}
