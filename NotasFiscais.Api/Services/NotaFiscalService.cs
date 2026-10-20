using System.Globalization;
using NotasFiscais.Api.DTOs;
using NotasFiscais.Api.Models;

namespace NotasFiscais.Api.Services;

public class NotaFiscalService : INotaFiscalService
{
    private readonly List<NotaFiscal> _notasEmMemoria = [];

    public NotaFiscal Cadastrar(CriarNotaFiscalRequest request)
    {
        var nota = new NotaFiscal
        {
            Numero = request.Numero,
            Cliente = request.Cliente,
            Valor = request.Valor,
            DataEmissao = request.DataEmissao
        };

        _notasEmMemoria.Add(nota);
        return nota;
    }

    public IEnumerable<NotaFiscalResponse> ListarTodas()
    {
        return _notasEmMemoria.Select(nota => MapearParaResponse(nota));
    }

    private static NotaFiscalResponse MapearParaResponse(NotaFiscal nota)
    {
        var culturaBrasileira = new CultureInfo("pt-BR");

        return new NotaFiscalResponse(
            Id: nota.Id,
            Numero: nota.Numero,
            Cliente: nota.Cliente,
            Valor: nota.Valor,
            ValorFormatado: nota.Valor.ToString("C", culturaBrasileira),
            DataEmissao: nota.DataEmissao.ToString("dd/MM/yyyy"),
            DataHoraCadastro: nota.DataHoraCadastro.ToString("dd/MM/yyyy HH:mm:ss")
        );
    }
}
