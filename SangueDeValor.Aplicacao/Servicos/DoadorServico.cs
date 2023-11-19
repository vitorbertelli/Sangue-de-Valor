using AutoMapper;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;

namespace SangueDeValor.Aplicacao.Servicos;

public class DoadorServico : IDoadorServico
{
    private IDoadorRepositorio _doadorRepositorio;
    private IMapper _mapper;

    public DoadorServico(IDoadorRepositorio doadorRepositorio, IMapper mapper)
    {
        _doadorRepositorio = doadorRepositorio;
        _mapper = mapper;
    }
    public async Task<DoadorDTO> GetDoador(int? id)
    {
        var doador = await _doadorRepositorio.GetDoador(id);
        return _mapper.Map<DoadorDTO>(doador);
    }

    public async Task<DoadorDTO> GetDoador(string? email)
    {
        var doador = await _doadorRepositorio.GetDoador(email);
        return _mapper.Map<DoadorDTO>(doador);
    }

    public async Task Remove(int? id)
    {
        var doador = _doadorRepositorio.GetDoador(id).Result;
        await _doadorRepositorio.Remove(doador);
    }
}
