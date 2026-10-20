using System.ComponentModel.DataAnnotations;

namespace NotasFiscais.Api.DTOs;

public record CriarNotaFiscalRequest(
    [Required(ErrorMessage = "Número da nota é obrigatório")]
    string Numero,

    [Required(ErrorMessage = "Cliente é obrigatório")]
    string Cliente,

    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    decimal Valor,

    [Required(ErrorMessage = "Data de emissão é obrigatória")]
    DateOnly DataEmissao
);
