using Microsoft.AspNetCore.Mvc;
using NotasFiscais.Api.DTOs;
using NotasFiscais.Api.Services;

namespace NotasFiscais.Api.Controllers;

[ApiController]
[Route("api/notas")]
public class NotasFiscaisController : ControllerBase
{
    private readonly INotaFiscalService _notaFiscalService;

    public NotasFiscaisController(INotaFiscalService notaFiscalService)
    {
        _notaFiscalService = notaFiscalService;
    }

    [HttpGet]
    public IActionResult ListarTodas()
    {
        var notas = _notaFiscalService.ListarTodas();
        return Ok(notas);
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody] CriarNotaFiscalRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var nota = _notaFiscalService.Cadastrar(request);
        return Created(string.Empty, nota); //sem rota
    }
}
