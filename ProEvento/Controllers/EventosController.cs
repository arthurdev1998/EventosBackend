using Microsoft.AspNetCore.Mvc;
using ProEvento.models;
using ProEvento.Services.Eventos;

namespace ProEvento.Controllers;

public class EventosController :ControllerBase
{
    private readonly EventoService _eventoService;

    public EventosController(EventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Evento),200)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _eventoService.GetEventoById(id);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Evento),200)]
    public async Task<IActionResult> GetAllEventos(int id)
    {
        var result = await _eventoService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("/tema")]
    [ProducesResponseType(typeof(Evento),200)]
    public async Task<IActionResult> GetAllEventosByTheme(string tema)
    {
        var result = await _eventoService.GetAllEventosByTemaAsync(tema);
        return Ok(result);
    }
}