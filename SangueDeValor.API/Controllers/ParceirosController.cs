using Microsoft.AspNetCore.Mvc;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Aplicacao.Servicos;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParceirosController : ControllerBase
{
    private readonly IParceiroServico _parceiroServico;
    public ParceirosController(IParceiroServico parceiroServico)
    {
        _parceiroServico = parceiroServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParceiroDTO>>> Get()
    {
        var parceiros = await _parceiroServico.GetParceiros();
        if (parceiros == null) return NotFound();
        return Ok(parceiros);
    }

    [HttpGet("categoria/{id:int}")]
    public async Task<ActionResult<IEnumerable<ParceiroDTO>>> GetPorCategoria(int id)
    {
        var parceiros = await _parceiroServico.GetParceirosPorCategoria(id);
        if (parceiros == null) return NotFound();
        return Ok(parceiros);
    }

    [HttpGet("{id:int}", Name = "GetParceiro")]
    public async Task<ActionResult<ParceiroDTO>> Get(int id)
    {
        var parceiro = await _parceiroServico.GetParceiroPorId(id);
        if (parceiro == null) return NotFound();
        return Ok(parceiro);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ParceiroDTO parceiroDTO)
    {
        if (parceiroDTO == null) return BadRequest();
        await _parceiroServico.Create(parceiroDTO);
        return new CreatedAtRouteResult("GetParceiro", new { id = parceiroDTO.Id }, parceiroDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var parceiro = await _parceiroServico.GetParceiroPorId(id);
        if (parceiro == null) return NotFound();
        await _parceiroServico.Remove(id);
        return Ok(parceiro);
    }
}
