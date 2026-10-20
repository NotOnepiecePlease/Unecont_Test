using System.Net.Http.Json;
using NotasFiscais.Web.Models;

namespace NotasFiscais.Web.Services;

public class NotaFiscalApiService : INotaFiscalApiService
{
    private readonly HttpClient _httpClient;

    public NotaFiscalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<NotaFiscalViewModel>> ListarTodasAsync()
    {
        var notas = await _httpClient.GetFromJsonAsync<List<NotaFiscalViewModel>>("api/notas");
        return notas ?? [];
    }

    public async Task<bool> CadastrarAsync(CriarNotaFiscalForm form)
    {
        var payload = new
        {
            form.Numero,
            form.Cliente,
            Valor = form.Valor!.Value,
            DataEmissao = DateOnly.FromDateTime(form.DataEmissao!.Value).ToString("yyyy-MM-dd")
        };

        var response = await _httpClient.PostAsJsonAsync("api/notas", payload);
        return response.IsSuccessStatusCode;
    }
}
