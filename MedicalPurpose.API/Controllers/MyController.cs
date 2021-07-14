using MedicalPurpose.API.User;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/my")]
	[Authorize]
	public class MyController : ControllerBase
	{
		private readonly IDoctorService _doctorService;
		private readonly IPatientService _patientService;

		public MyController(IDoctorService doctorService,
			IPatientService patientService)
		{
			_doctorService = doctorService;
			_patientService = patientService;
		}

		[HttpGet("info")]
		public async Task<IActionResult> GetMyInfo()
		{
			int userId = User.Id();
			bool isDoctor = User.IsDoctor();

			if (isDoctor)
			{
				var doctor = await _doctorService.FindByIdAsync(userId);
				if (doctor != null)
				{
					return Ok(doctor);
				}
			}
			else
			{
				var patient = await _patientService.FindByIdAsync(userId);
				if (patient != null)
				{
					return Ok(patient);
				}
			}

			return BadRequest("Authorization error.");
		}
	}
}
