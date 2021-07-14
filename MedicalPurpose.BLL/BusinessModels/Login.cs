using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.BLL.BusinessModels
{
	public class Login
	{
		[Required(ErrorMessage = "Field is required.")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "The email must be in the correct format.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Field is required.")]
		[DataType(DataType.Password)]
		[StringLength(50, MinimumLength = 6, ErrorMessage = "The password must have at least {2} characters.")]
		public string Password { get; set; }
	}
}
