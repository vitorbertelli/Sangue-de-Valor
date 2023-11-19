using CleanArchMvc.API.Models;
using Microsoft.AspNetCore.Mvc;
using SangueDeValor.API.Models;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IAutenticacaoServico _autenticacaoServico;
    public AutenticacaoController(IAutenticacaoServico autenticacaoServico)
    {
        _autenticacaoServico = autenticacaoServico;
    }

    [HttpPost("cadastro")]
    public async Task<ActionResult<TokenDTO>> Cadastrar([FromBody] CadastroDTO cadastroDTO)
    {
        var resultado = await _autenticacaoServico.Cadastro(cadastroDTO);

        if (resultado != null) return Ok($"O doador {cadastroDTO.Email} foi criado com sucesso.");

        ModelState.AddModelError(string.Empty, "Tentativa de cadastro inválido.");
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Loginn([FromBody] LoginDTO loginDTO)
    {
        var resultado = await _autenticacaoServico.Login(loginDTO);

        if (resultado != null) return Ok(resultado);

        ModelState.AddModelError(string.Empty, "Tentativa de login inválido.");
        return BadRequest(ModelState);
    }
}
