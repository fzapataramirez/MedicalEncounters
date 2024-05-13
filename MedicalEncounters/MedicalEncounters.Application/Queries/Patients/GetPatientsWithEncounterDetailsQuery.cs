using MediatR;
using MedicalEncounters.Application.Configuration;
using MedicalEncounters.Application.DTOs.Patients;
using MedicalEncounters.Application.Enums;
using MedicalEncounters.Application.Exceptions;
using MedicalEncounters.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace MedicalEncounters.Application.Queries.Patients
{
    public class GetPatientsWithEncounterDetailsQuery : IRequest<IEnumerable<PatientEncountersDetailDto>>
    {
    }

    public class GetPatientsWithEncounterDetailsQueryHandler : IRequestHandler<GetPatientsWithEncounterDetailsQuery, IEnumerable<PatientEncountersDetailDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly PatientQueryOptions _patientOptions;

        public GetPatientsWithEncounterDetailsQueryHandler(
            IPatientRepository patientRepository,
            IOptions<PatientQueryOptions> patientOptions)
        {
            _patientRepository = patientRepository;
            _patientOptions = patientOptions.Value;
        }

        public async Task<IEnumerable<PatientEncountersDetailDto>> Handle(GetPatientsWithEncounterDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = await _patientRepository.GetPatientsWithEncounters(_patientOptions.MinCitiesRequired);

            if(data is null || !data.Any())
            {
                throw new NotFoundException();
            }

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
