using MedicalPurpose.BLL.DTO.Prescription;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IPrescriptionService
	{
		Task<PrescriptionDTO> CreateAsync(CreatePrescriptionDTO prescription);

		Task<PrescriptionDTO> FindByIdAsync(int prescriptionId);

		Task<IEnumerable<PrescriptionDTO>> FindByDoctorAsync(int doctorId);

		Task<IEnumerable<PrescriptionDTO>> FindByPatientAsync(int patientId);
	}
}
