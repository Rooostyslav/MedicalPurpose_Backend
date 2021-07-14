using MedicalPurpose.BLL.DTO.Doctor;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/doctors")]
	public class DoctorsController : ControllerBase
	{
		private readonly IDoctorService _doctorService;

		public DoctorsController(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDTO doctor)
		{
			var result = await _doctorService.CreateAsync(doctor);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create doctor!");
		}
	}
}
