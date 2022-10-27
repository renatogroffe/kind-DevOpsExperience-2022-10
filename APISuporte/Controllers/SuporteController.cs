using Microsoft.AspNetCore.Mvc;
using APISuporte.Models;
using APISuporte.Services;

namespace APISuporte.Controllers;

[ApiController]
[Route("[controller]")]
public class SuporteController : ControllerBase
{
    private readonly ILogger<SuporteController> _logger;
    private readonly ChamadosService _chamadosService;

    public SuporteController(ILogger<SuporteController> logger,
        ChamadosService chamadosService)
    {
        _logger = logger;
        _chamadosService = chamadosService;
    }

    [HttpGet("{idChamado}")]
    [ProducesResponseType(typeof(DetalhesChamado), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DetalhesChamado> Get(string idChamado)
    {
        var detalhesChamado = _chamadosService.Get(idChamado);
        if (detalhesChamado is not null)
        {
            _logger.LogInformation($"Retornando dados do Chamado {idChamado}...");
            return detalhesChamado;
        }
        else
        {
            _logger.LogError($"Nao foram encontradas informacoes para o Chamado {idChamado}!");
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultadoInclusao), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ResultadoInclusao Post(RequisicaoSuporte requisicaoSuporte)
    {
        var resultado = _chamadosService.Save(requisicaoSuporte);
        _logger.LogInformation($"Id do novo Chamado: {resultado.IdChamado}");
        return resultado;
    }
}