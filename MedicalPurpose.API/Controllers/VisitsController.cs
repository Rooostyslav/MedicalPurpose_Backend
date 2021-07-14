using MedicalPurpose.API.User;
using MedicalPurpose.BLL.DTO.Visit;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/visits")]
	public class VisitsController : ControllerBase
	{
		private readonly IVisitService _visitService;

		public VisitsController(IVisitService visitService)
		{
			_visitService = visitService;
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateVisit([FromBody] CreateVisitDTO visit)
		{
			var result = await _visitService.CreateAsync(visit);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create doctor!");
		}

		[Authorize]
		[HttpGet("my")]
		public async Task<IActionResult> GetMyVisits()
		{
			int userId = User.Id();
			IEnumerable<VisitDTO> visits;

			if (User.IsDoctor())
			{
				visits = await _visitService.FindByDoctorAsync(userId);
			}
			else
			{
				visits = await _visitService.FindByPatientAsync(userId);
			}

			if (visits.Count() > 0)
			{
				return Ok(visits);
			}

			return NoContent();
		}
	}
}
