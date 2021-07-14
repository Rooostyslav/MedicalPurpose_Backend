using MedicalPurpose.BLL.DTO.Medicine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IMedicineService
	{
		Task<MedicineDTO> CreateAsync(CreateMedicineDTO medicine);

		Task<IEnumerable<MedicineDTO>> FindAllAsync();

		Task<IEnumerable<PrescriptionMedicineDTO>> FindByPrescriptionAsync(int prescriptionId);
	}
}
