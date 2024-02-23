using ProEvento.Interfaces;
using ProEvento.models;

namespace ProEvento.Services.Eventos;

public delegate Task<Evento[]> Functiooon();

public class EventoService
{
    private readonly IEventoRepository _eventoRepository;
    private readonly IUnitofWork _unitOfWord;

    public EventoService(IEventoRepository eventoRepository, IUnitofWork unitofWork)
    {
        _eventoRepository = eventoRepository;
        _unitOfWord = unitofWork;
    }

    public async Task<Evento[]> GetAllAsync()
    {
        return await ExcepetionHandler.HandleAsync(async () =>
        {
            var registrosAsync = await _eventoRepository.GetAllEventosAsync();
            await _unitOfWord.Commit();
            return registrosAsync;
        });
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        return await ExcepetionHandler.HandleAsync(async () =>
        {
            var registros = await _eventoRepository.GetAllEventosByTemaAsync(tema);
            await _unitOfWord.Commit();
            return registros;
        });
    }

    public async Task<Evento> GetEventoById(int id, bool inclutePalestrantes = false, bool asNoTracking = false)
    {
        return await ExcepetionHandler.HandleAsync(async () =>
                {
                    var registros = await _eventoRepository.GetEventoById(id);
                    await _unitOfWord.Commit();
                    return registros;
                });
    }
}