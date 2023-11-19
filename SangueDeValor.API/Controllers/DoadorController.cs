using Microsoft.AspNetCore.Mvc;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Aplicacao.Servicos;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoadorController : ControllerBase
{
    private readonly IDoadorServico _doadorServico;

    public DoadorController(IDoadorServico doadorServico)
    {
        _doadorServico = doadorServico;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produto = await _doadorServico.GetDoador(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<ProdutoDTO>> Get(string email)
    {
        var produto = await _doadorServico.GetDoador(email);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var produto = await _doadorServico.GetDoador(id);
        if (produto == null) return NotFound();
        await _doadorServico.Remove(id);
        return Ok(produto);
    }
}
