using Microsoft.AspNetCore.Mvc;
using ProEvento.models;
using ProEvento.Services.Eventos;

namespace ProEvento.Controllers;

public class EventosController : ControllerBase
{
    private readonly EventoService _eventoService;

    public EventosController(EventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Evento), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _eventoService.GetEventoById(id);

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Evento), 200)]
    public async Task<IActionResult> GetAllEventos(int id)
    {
        var result = await _eventoService.GetAllAsync();
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpGet("/tema")]
    [ProducesResponseType(typeof(Evento), 200)]
    public async Task<IActionResult> GetAllEventosByTheme(string tema)
    {
        var result = await _eventoService.GetAllEventosByTemaAsync(tema);
        return StatusCode(StatusCodes.Status200OK);
    }
}