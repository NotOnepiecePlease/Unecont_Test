using NotasFiscais.Web.Models;

namespace NotasFiscais.Web.Services;

public interface INotaFiscalApiService
{
    Task<List<NotaFiscalViewModel>> ListarTodasAsync();
    Task<bool> CadastrarAsync(CriarNotaFiscalForm form);
}
