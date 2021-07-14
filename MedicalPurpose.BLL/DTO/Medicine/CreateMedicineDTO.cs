using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.BLL.DTO.Medicine
{
	public class CreateMedicineDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Instruction { get; set; }

		[Required]
		public double PriceForOne { get; set; }
	}
}
