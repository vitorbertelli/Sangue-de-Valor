namespace CleanArchMvc.API.Models;

public class TokenDTO
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
