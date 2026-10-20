namespace NotasFiscais.Api.DTOs;

public record NotaFiscalResponse(
    Guid Id,
    string Numero,
    string Cliente,
    decimal Valor,
    string ValorFormatado,
    string DataEmissao,
    string DataHoraCadastro
);
