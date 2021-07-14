using MedicalPurpose.Auth.Common;
using MedicalPurpose.BLL.BusinessModels;
using MedicalPurpose.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalPurpose.Auth.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> _authOptions;
		private readonly IDoctorService _doctorService;
		private readonly IPatientService _patientService;

		public AuthController(IOptions<AuthOptions> authOptions,
			IDoctorService doctorService,
			IPatientService patientService)
		{
			_authOptions = authOptions;
			_doctorService = doctorService;
			_patientService = patientService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] Login login)
		{
			var patient = await _patientService.FindByLoginAsync(login);
			if (patient != null)
			{
				string token = GenerateJWT(patient.Id);
				return Ok(new { accessToken = token });
			}

			var doctor = await _doctorService.FindByLoginAsync(login);
			if (doctor != null)
			{
				string token = GenerateJWT(doctor.Id, true);
				return Ok(new { accessToken = token });
			}

			return BadRequest("Error email or password.");
		}

		private string GenerateJWT(int userId, bool isDoctor = false)
		{
			var authParams = _authOptions.Value;

			var securityKey = authParams.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, userId.ToString())
			};

			if (isDoctor)
			{
				claims.Add(new Claim("user", "doctor"));
				claims.Add(new Claim("role", "admin"));
			}
			else
			{
				claims.Add(new Claim("user", "patient"));
				claims.Add(new Claim("role", "user"));
			}

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
