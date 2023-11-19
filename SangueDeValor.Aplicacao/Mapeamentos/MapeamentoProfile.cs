using AutoMapper;
using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Dominio.Entidades;
using System.Drawing;

namespace SangueDeValor.Aplicacao.Mapeamentos;

public class MapeamentoProfile : Profile
{
    public MapeamentoProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Parceiro, ParceiroDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Doador, DoadorDTO>().ReverseMap();
    }
}
