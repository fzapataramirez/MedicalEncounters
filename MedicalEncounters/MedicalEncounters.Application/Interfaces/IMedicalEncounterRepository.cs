using MedicalEncounters.Domain.Entities;

namespace MedicalEncounters.Application.Interfaces
{
    public interface IMedicalEncounterRepository
    {
        Task<IEnumerable<MedicalEncounter>> GetAll();
    }
}
