using MediatR;
using MedicalEncounters.Application.DTOs.Patients;
using MedicalEncounters.Application.Enums;
using MedicalEncounters.Application.Interfaces;

namespace MedicalEncounters.Application.Queries.Patients
{
    public class GetPatientsWithEncounterDetailsQuery : IRequest<IEnumerable<PatientEncountersDetailDto>>
    {
    }

    public class GetPatientsWithEncounterDetailsQueryHandler : IRequestHandler<GetPatientsWithEncounterDetailsQuery, IEnumerable<PatientEncountersDetailDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private const int MIN_CITIES_REQUIRED = 2;

        public GetPatientsWithEncounterDetailsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientEncountersDetailDto>> Handle(GetPatientsWithEncounterDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = await _patientRepository.GetPatientsWithEncounters(MIN_CITIES_REQUIRED);

            return data.Select(patientData =>
            {
                return new PatientEncountersDetailDto
                {
                    FullName = $"{patientData.LastName}, {patientData.FirstName}",
                    VisitedCities = patientData.VisitedCities,
                    Category = patientData.Age < 16 ? PatientCategory.A.ToString() : PatientCategory.B.ToString()
                };
            });
        }
    }
}
