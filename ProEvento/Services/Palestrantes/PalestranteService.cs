using ProEvento.Interfaces;
using ProEvento.models;

namespace ProEvento.Services.Palestrantes;

public class PalestranteService
{
    private readonly IPalestranteRepository _palestranteRepository;
    private readonly IUnitofWork _unitofWork;

    public PalestranteService(IPalestranteRepository palestranteRepository, IUnitofWork unitofWork)
    {
        _palestranteRepository = palestranteRepository;
        _unitofWork = unitofWork;
    }

    public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos, bool asNoTracking)
    {
        return await ExcepetionHandler.HandleAsync(async () =>
        {
            var registros = await _palestranteRepository.GetAllPalestrantesAsync(includeEventos, asNoTracking);
            await _unitofWork.Commit();
            return registros;
        });
    }

    public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos, bool asNoTracking)
    {
        return await ExcepetionHandler.HandleAsync(async () =>
        {
            var registros = await _palestranteRepository.GetAllPalestrantesByNomeAsync(nome);
            await _unitofWork.Commit();
            return registros;
        });
    }

    public async Task<Palestrante> GetPalestranteById(int id, bool includeEventos, bool asNoTracking)
    {
        return await ExcepetionHandler.HandleAsync(async () =>
        {
            var registros = await _palestranteRepository.GetPalestranteById(id);
            await _unitofWork.Commit();
            return registros;
        });
    }
}