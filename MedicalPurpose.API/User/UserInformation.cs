using System;
using System.Security.Claims;

namespace MedicalPurpose.API.User
{
	public static class UserInformation
	{
		public static int Id(this ClaimsPrincipal claims)
		{
			Int32.TryParse(claims
				.FindFirstValue(ClaimsIdentity.DefaultNameClaimType + "identifier"), out int id);
			return id;
		}

		public static bool IsDoctor(this ClaimsPrincipal claims)
		{
			string user = claims.FindFirstValue("user");
			return user == "doctor";
		}
	}
}
