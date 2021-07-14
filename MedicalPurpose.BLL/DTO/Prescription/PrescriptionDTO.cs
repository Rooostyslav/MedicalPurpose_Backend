using MedicalPurpose.BLL.DTO.Doctor;
using MedicalPurpose.BLL.DTO.Medicine;
using MedicalPurpose.BLL.DTO.Patient;
using System.Collections.Generic;

namespace MedicalPurpose.BLL.DTO.Prescription
{
	public class PrescriptionDTO
	{
		public int Id { get; set; }

		public int DoctorId { get; set; }

		public DoctorDTO Doctor { get; set; }

		public int PatientId { get; set; }

		public PatientDTO Patient { get; set; }

		public string Description { get; set; }

		public IEnumerable<PrescriptionMedicineDTO> Medicines { get; set; }
	}
}
