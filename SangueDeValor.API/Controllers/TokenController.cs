using CleanArchMvc.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SangueDeValor.Dominio.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authentication;
    private readonly IConfiguration _configuration;
    public TokenController(IAuthenticate authentication, IConfiguration configuration)
    {
        _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        _configuration = configuration;
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
    {
        var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

        if (result) return GenerateToken(userInfo);

        ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
        return BadRequest(ModelState);
    }

    [HttpPost("RegisterUser")]
    public async Task<ActionResult> Register([FromBody] LoginModel userInfo)
    {
        var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

        if (result) return Ok($"Usuário {userInfo.Email} foi criado com sucesso.");

        ModelState.AddModelError(string.Empty, "Tentativa de registro inválido.");
        return BadRequest(ModelState);
    }

    private UserToken GenerateToken(LoginModel userInfo)
    {
        var claims = new[]
        {
            new Claim("email", userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f43gds5gT"));

        var credencials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            expires: expiration,
            signingCredentials: credencials
            );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
