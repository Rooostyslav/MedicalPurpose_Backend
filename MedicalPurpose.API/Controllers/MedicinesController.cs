using MedicalPurpose.BLL.DTO.Medicine;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/medicines")]
	public class MedicinesController : ControllerBase
	{
		private readonly IMedicineService _medicineService;

		public MedicinesController(IMedicineService medicineService)
		{
			_medicineService = medicineService;
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateMedecine([FromBody] CreateMedicineDTO medicine)
		{
			var result = await _medicineService.CreateAsync(medicine);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create medicine!");
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetMedicines()
		{
			var medicines = await _medicineService.FindAllAsync();

			if (medicines.Count() > 0)
			{
				return Ok(medicines);
			}

			return NoContent();
		}
	}
}
