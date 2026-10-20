using NotasFiscais.Api.DTOs;
using NotasFiscais.Api.Models;

namespace NotasFiscais.Api.Services;

public interface INotaFiscalService
{
    NotaFiscal Cadastrar(CriarNotaFiscalRequest request);
    IEnumerable<NotaFiscalResponse> ListarTodas();
}
