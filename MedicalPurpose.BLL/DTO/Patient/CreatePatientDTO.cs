using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.BLL.DTO.Patient
{
	public class CreatePatientDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
