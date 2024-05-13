using MedicalEncounters.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEncounters.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MedicalEncountersController : Controller
    {
        private readonly IMedicalEncounterRepository _medicalEncounterRepository;
        
        public MedicalEncountersController(IMedicalEncounterRepository medicalEncounterRepository)
        {
            _medicalEncounterRepository = medicalEncounterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _medicalEncounterRepository.GetAll());
        }
    }
}
