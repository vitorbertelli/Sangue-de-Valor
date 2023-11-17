using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaServico _categoriaServico;

    public CategoriaController(ICategoriaServico categoriaServico)
    {
        _categoriaServico = categoriaServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categorias = await _categoriaServico.GetCategorias();
        if(categorias == null) return NotFound();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _categoriaServico.GetCategoriaPorId(id);
        if (categoria == null) return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        if(categoriaDTO == null) return BadRequest();
        await _categoriaServico.Create(categoriaDTO);
        return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoria = await _categoriaServico.GetCategoriaPorId(id);
        if (categoria == null) return NotFound();
        await _categoriaServico.Remove(id);
        return Ok(categoria);
    }
}
