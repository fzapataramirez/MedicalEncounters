using MedicalEncounters.Domain.Entities;

namespace MedicalEncounters.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientWithEncounterData>> GetPatientsWithEncounters(int minCitiesRequired);
    }
}
