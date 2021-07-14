using MedicalPurpose.BLL.DTO.Patient;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/patients")]
	public class PatientsController : ControllerBase
	{
		private readonly IPatientService _patientService;

		public PatientsController(IPatientService patientService)
		{
			_patientService = patientService;
		}

		[HttpPost]
		public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDTO patient)
		{
			var result = await _patientService.CreateAsync(patient);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create patient!");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> GetPatients()
		{
			var patients = await _patientService.FindAllAsync();

			if (patients.Count() > 0)
			{
				return Ok(patients);
			}

			return NoContent();
		}
	}
}
