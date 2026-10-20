namespace NotasFiscais.Api.Models;

public class NotaFiscal
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Numero { get; init; }
    public required string Cliente { get; init; }
    public decimal Valor { get; init; }
    public DateOnly DataEmissao { get; init; }
    public DateTime DataHoraCadastro { get; init; } = DateTime.Now;
}
