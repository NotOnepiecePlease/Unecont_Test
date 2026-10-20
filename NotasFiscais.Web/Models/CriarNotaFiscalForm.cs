using System.ComponentModel.DataAnnotations;

namespace NotasFiscais.Web.Models;

public class CriarNotaFiscalForm
{
    [Required(ErrorMessage = "Número da nota é obrigatório")]
    public string Numero { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nome do cliente é obrigatório")]
    public string Cliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    public decimal? Valor { get; set; }

    [Required(ErrorMessage = "Data de emissão é obrigatória")]
    public DateTime? DataEmissao { get; set; }
}
