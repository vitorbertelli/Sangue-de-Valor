using CleanArchMvc.API.Models;
using SangueDeValor.API.Models;
using SangueDeValor.Aplicacao.DTOs;

namespace SangueDeValor.Aplicacao.Interfaces;

public interface IAutenticacaoServico
{
    Task<TokenDTO> Cadastro(CadastroDTO cadastroDTO);
    Task<TokenDTO> Login(LoginDTO loginDTO);
}
