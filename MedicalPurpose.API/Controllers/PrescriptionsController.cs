using MedicalPurpose.API.User;
using MedicalPurpose.BLL.DTO.Prescription;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.API.Controllers
{
	[ApiController]
	[Route("api/prescriptions")]
	public class PrescriptionsController : ControllerBase
	{
		private readonly IPrescriptionService _prescriptionService;
		private readonly IQRCodeService _qRCodeService;

		public PrescriptionsController(IPrescriptionService prescriptionService,
			IQRCodeService qRCodeService)
		{
			_prescriptionService = prescriptionService;
			_qRCodeService = qRCodeService;
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionDTO prescription)
		{
			var result = await _prescriptionService.CreateAsync(prescription);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create doctor!");
		}

		[HttpGet("{prescriptionId}")]
		[Authorize]
		public async Task<IActionResult> GetPrescriptionById(int prescriptionId)
		{
			var result = await _prescriptionService.FindByIdAsync(prescriptionId);

			if (result != null)
			{
				return Ok(result);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyPrescriptions()
		{
			int userId = User.Id();
			IEnumerable<PrescriptionDTO> prescriptions;

			if (User.IsDoctor())
			{
				prescriptions = await _prescriptionService.FindByDoctorAsync(userId);
			}
			else
			{
				prescriptions = await _prescriptionService.FindByPatientAsync(userId);
			}

			if (prescriptions.Count() > 0)
			{
				return Ok(prescriptions);
			}

			return NoContent();
		}

		[HttpGet("qrcode/{prescriptionId}")]
		public async Task<IActionResult> GetQRCode(int prescriptionId)
		{
			var qrCodeFilePath = await _qRCodeService.FindPathToQRCoreAsync(prescriptionId);
			if (qrCodeFilePath.Length == 0)
			{
				return NotFound("QR code not exist");
			}

			string photoType = "image/png";
			string fileName = "qrcode" + prescriptionId;

			return PhysicalFile(qrCodeFilePath, photoType, fileName);
		}
	}
}
