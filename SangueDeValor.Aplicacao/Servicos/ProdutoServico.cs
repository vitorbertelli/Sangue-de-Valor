using AutoMapper;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using System.Drawing;

namespace SangueDeValor.Aplicacao.Servicos;

public class ProdutoServico : IProdutoServico
{
    private IProdutoRepositorio _produtoRepositorio;
    private IMapper _mapper;

    public ProdutoServico(IProdutoRepositorio produtoRepositorio, IMapper mapper)
    {
        _produtoRepositorio = produtoRepositorio;
        _mapper = mapper;
    }
    public async Task Create(ProdutoDTO produtoDTO)
    {
        var produto = _mapper.Map<Produto>(produtoDTO);
        await _produtoRepositorio.Create(produto);
    }

    public async Task<ProdutoDTO> GetProdutoPorId(int? id)
    {
        var produto = await _produtoRepositorio.GetProdutoPorId(id);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        var produtos = await _produtoRepositorio.GetProdutos();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutosPorParceiro(int? parceiroId)
    {
        var produtos = await _produtoRepositorio.GetProdutosPorParceiro(parceiroId);
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task Remove(int? id)
    {
        var produto = _produtoRepositorio.GetProdutoPorId(id).Result;
        await _produtoRepositorio.Remove(produto);
    }
}
