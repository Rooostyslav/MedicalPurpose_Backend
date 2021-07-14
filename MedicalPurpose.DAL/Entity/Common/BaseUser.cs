using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPurpose.DAL.Entity.Common
{
	public abstract class BaseUser
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[Column(Order = 4)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
