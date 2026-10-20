namespace NotasFiscais.Web.Models;

public class NotaFiscalViewModel
{
    public Guid Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string ValorFormatado { get; set; } = string.Empty;
    public string DataEmissao { get; set; } = string.Empty;
    public string DataHoraCadastro { get; set; } = string.Empty;
}
