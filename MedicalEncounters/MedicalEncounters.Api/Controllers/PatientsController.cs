using MediatR;
using MedicalEncounters.Application.Queries.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEncounters.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PatientsController : Controller
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("encounters")]
        public async Task<IActionResult> EncounterDetails()
        {
            var result = await _mediator.Send(new GetPatientsWithEncounterDetailsQuery());

            return Ok(result);
        }
    }
}
