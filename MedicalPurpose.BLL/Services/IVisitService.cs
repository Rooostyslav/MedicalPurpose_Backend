using MedicalPurpose.BLL.DTO.Visit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IVisitService
	{
		Task<VisitDTO> CreateAsync(CreateVisitDTO visit);

		Task<IEnumerable<VisitDTO>> FindByDoctorAsync(int doctorId);

		Task<IEnumerable<VisitDTO>> FindByPatientAsync(int patientId);
	}
}
