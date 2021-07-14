using MedicalPurpose.BLL.BusinessModels;
using MedicalPurpose.BLL.DTO.Doctor;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IDoctorService
	{
		Task<DoctorDTO> CreateAsync(CreateDoctorDTO doctor);

		Task<DoctorDTO> FindByLoginAsync(Login login);

		Task<DoctorDTO> FindByIdAsync(int id);
	}
}
