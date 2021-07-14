using System.Collections.Generic;

namespace MedicalPurpose.BLL.DTO.Prescription
{
	public class CreatePrescriptionDTO
	{
		public int DoctorId { get; set; }

		public int PatientId { get; set; }

		public string Description { get; set; }

		public IEnumerable<MedicineAmountDTO> Medicines { get; set; }
	}
}
