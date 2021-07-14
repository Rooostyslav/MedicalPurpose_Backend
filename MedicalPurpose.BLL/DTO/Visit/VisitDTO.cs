using MedicalPurpose.BLL.DTO.Doctor;
using MedicalPurpose.BLL.DTO.Patient;
using System;

namespace MedicalPurpose.BLL.DTO.Visit
{
	public class VisitDTO
	{
		public int Id { get; set; }

		public int DoctorId { get; set; }

		public DoctorDTO Doctor { get; set; }

		public int PatientId { get; set; }

		public PatientDTO Patient { get; set; }

		public DateTime DateTime { get; set; }
	}
}
