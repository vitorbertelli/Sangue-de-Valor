using AutoMapper;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;

namespace SangueDeValor.Aplicacao.Servicos;

public class ParceiroServico : IParceiroServico
{
    private IParceiroRepositorio _parceiroRepositorio;
    private IMapper _mapper;

    public ParceiroServico(IParceiroRepositorio parceiroRepositorio, IMapper mapper)
    {
        _parceiroRepositorio = parceiroRepositorio;
        _mapper = mapper;
    }

    public async Task Create(ParceiroDTO parceiroDTO)
    {
        var parceiro = _mapper.Map<Parceiro>(parceiroDTO);
        await _parceiroRepositorio.Create(parceiro);
    }

    public async Task<ParceiroDTO> GetParceiroPorId(int? id)
    {
        var parceiro = await _parceiroRepositorio.GetParceiroPorId(id);
        return _mapper.Map<ParceiroDTO>(parceiro);
    }

    public async Task<IEnumerable<ParceiroDTO>> GetParceiros()
    {
        var parceiros = await _parceiroRepositorio.GetParceiros();
        return _mapper.Map<IEnumerable<ParceiroDTO>>(parceiros);
    }

    public async Task<IEnumerable<ParceiroDTO>> GetParceirosPorCategoria(int? categoriaId)
    {
        var parceiros = await _parceiroRepositorio.GetParceirosPorCategoria(categoriaId);
        return _mapper.Map<IEnumerable<ParceiroDTO>>(parceiros);
    }

    public async Task Remove(int? id)
    {
        var parceiro = _parceiroRepositorio.GetParceiroPorId(id).Result;
        await _parceiroRepositorio.Remove(parceiro);
    }
}
