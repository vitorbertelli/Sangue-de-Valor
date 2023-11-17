using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;

namespace SangueDeValor.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoServico _produtoServico;
    public ProdutosController(IProdutoServico produtoServico)
    {
        _produtoServico = produtoServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtos = await _produtoServico.GetProdutos();
        if (produtos == null) return NotFound();
        return Ok(produtos);
    }

    [HttpGet("parceiro/{id:int}")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetPorCategoria(int id)
    {
        var produtos = await _produtoServico.GetProdutosPorParceiro(id);
        if (produtos == null) return NotFound();
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "GetProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produto = await _produtoServico.GetProdutoPorId(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
    {
        if (produtoDTO == null) return BadRequest();
        await _produtoServico.Create(produtoDTO);
        return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var produto = await _produtoServico.GetProdutoPorId(id);
        if (produto == null) return NotFound();
        await _produtoServico.Remove(id);
        return Ok(produto);
    }
}
