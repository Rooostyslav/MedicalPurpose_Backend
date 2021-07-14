using MedicalPurpose.BLL.BusinessModels;
using MedicalPurpose.BLL.DTO.Patient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IPatientService
	{
		Task<PatientDTO> CreateAsync(CreatePatientDTO patient);

		Task<IEnumerable<PatientDTO>> FindAllAsync();

		Task<PatientDTO> FindByLoginAsync(Login login);

		Task<PatientDTO> FindByIdAsync(int id);
	}
}
