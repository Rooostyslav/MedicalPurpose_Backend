
namespace MedicalPurpose.BLL.DTO.Medicine
{
	public class PrescriptionMedicineDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Instruction { get; set; }

		public int Amount { get; set; }

		public double PriceForOne { get; set; }

		public double TotalPrice { get; set; }
	}
}
