using MedicalEncounters.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEncounters.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PatientsController : Controller
    {
        private readonly IPatientRepository _medicalEncounterRepository;
        
        public PatientsController(IPatientRepository medicalEncounterRepository)
        {
            _medicalEncounterRepository = medicalEncounterRepository;
        }

        [HttpGet("encounters")]
        public async Task<IActionResult> EncounterDetails()
        {
            return Ok(await _medicalEncounterRepository.GetPatientsWithEncounters(2));
        }
    }
}
