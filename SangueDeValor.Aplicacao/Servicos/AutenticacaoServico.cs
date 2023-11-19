using AutoMapper;
using CleanArchMvc.API.Models;
using SangueDeValor.API.Models;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using SangueDeValor.Dominio.Enumeradores;
using SangueDeValor.Aplicacao.DTOs;

namespace SangueDeValor.Aplicacao.Servicos;

public class AutenticacaoServico : IAutenticacaoServico
{
    private IDoadorRepositorio _doadorRepositorio;
    private IMapper _mapper;

    public AutenticacaoServico(IDoadorRepositorio doadorRepositorio, IMapper mapper)
    {
        _doadorRepositorio = doadorRepositorio;
        _mapper = mapper;
    }

    public async Task<TokenDTO> Cadastro(CadastroDTO cadastroDTO)
    {
        var doador = new Doador(cadastroDTO.NomeCompleto, cadastroDTO.Email, cadastroDTO.Senha, (TipoSanguineo)cadastroDTO.TipoSanguineo, cadastroDTO.Peso);
        doador.SetSenhaHash(BCrypt.Net.BCrypt.HashPassword(cadastroDTO.Senha));
        await _doadorRepositorio.Create(doador);
        return GenerateToken(cadastroDTO.Email);
    }

    public async Task<TokenDTO> Login(LoginDTO loginDTO)
    {
        var doador = await _doadorRepositorio.GetDoador(loginDTO.Email);

        if(doador  == null)
        {
            throw new Exception(""); 
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDTO.Senha, doador.Senha))
        {
            throw new Exception("");
        }

        return GenerateToken(loginDTO.Email);
    }

    private TokenDTO GenerateToken(string email)
    {
        var claims = new[]
        {
            new Claim("email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f43gds5gT"));

        var credencials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(60);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            expires: expiration,
            signingCredentials: credencials
            );

        return new TokenDTO()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
