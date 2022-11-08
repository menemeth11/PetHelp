using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces;

public interface IRasaRepository
{
    public Task<RasaDTO[]> GetAllDogTypes();
}
