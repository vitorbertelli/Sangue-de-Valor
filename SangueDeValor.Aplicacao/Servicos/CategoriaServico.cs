using AutoMapper;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;

namespace SangueDeValor.Aplicacao.Servicos;

public class CategoriaServico : ICategoriaServico
{
    private ICategoriaRepositorio _categoriaRepositorio;
    private IMapper _mapper;

    public CategoriaServico(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
    {
        _categoriaRepositorio = categoriaRepositorio;
        _mapper = mapper;
    }

    public async Task Create(CategoriaDTO categoriaDTO)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDTO);
        await _categoriaRepositorio.Create(categoria);
    }

    public async Task<CategoriaDTO> GetCategoriaPorId(int? id)
    {
        var categoria = await _categoriaRepositorio.GetCategoriaPorId(id);
        return _mapper.Map<CategoriaDTO>(categoria);
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        var categorias = await _categoriaRepositorio.GetCategorias();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias); 
    }

    public async Task Remove(int? id)
    {
        var categoria = _categoriaRepositorio.GetCategoriaPorId(id).Result;
        await _categoriaRepositorio.Remove(categoria);
    }
}
