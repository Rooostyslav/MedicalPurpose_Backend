using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.BLL.DTO.Doctor
{
	public class CreateDoctorDTO
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

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Position { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string KindOfActivity { get; set; }
	}
}
