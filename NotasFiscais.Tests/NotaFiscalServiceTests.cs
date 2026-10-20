using NotasFiscais.Api.DTOs;
using NotasFiscais.Api.Services;

namespace NotasFiscais.Tests;

public class NotaFiscalServiceTests
{
    private readonly NotaFiscalService _service = new();

    [Fact]
    public void Cadastrar_DevePersistirNotaComOsDadosInformados()
    {
        var request = new CriarNotaFiscalRequest(
            Numero: "NF-001",
            Cliente: "Empresa Teste Ltda",
            Valor: 1500.00m,
            DataEmissao: new DateOnly(2025, 10, 1)
        );

        var notaCadastrada = _service.Cadastrar(request);

        Assert.Equal("NF-001", notaCadastrada.Numero);
        Assert.Equal("Empresa Teste Ltda", notaCadastrada.Cliente);
        Assert.Equal(1500.00m, notaCadastrada.Valor);
        Assert.Equal(new DateOnly(2025, 10, 1), notaCadastrada.DataEmissao);
    }

    [Fact]
    public void ListarTodas_DeveRetornarTodasAsNotasCadastradas()
    {
        _service.Cadastrar(new CriarNotaFiscalRequest("NF-010", "Cliente A", 100m, new DateOnly(2025, 1, 1)));
        _service.Cadastrar(new CriarNotaFiscalRequest("NF-011", "Cliente B", 200m, new DateOnly(2025, 2, 1)));

        var notas = _service.ListarTodas().ToList();

        Assert.Equal(2, notas.Count);
    }

    [Fact]
    public void ListarTodas_DeveFormatarValorComoMoedaBrasileira()
    {
        _service.Cadastrar(new CriarNotaFiscalRequest("NF-020", "Cliente C", 1500m, new DateOnly(2025, 3, 1)));

        var nota = _service.ListarTodas().First();

        Assert.StartsWith("R$", nota.ValorFormatado);
    }
}
