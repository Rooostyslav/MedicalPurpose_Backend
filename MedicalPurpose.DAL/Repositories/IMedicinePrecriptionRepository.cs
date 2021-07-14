using MedicalPurpose.DAL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IMedicinePrecriptionRepository
	{
		Task<MedicinePrescription> AddAsync(MedicinePrescription medicinePrescription);

		Task<IEnumerable<MedicinePrescription>> FindByPrescriptionAsync(int prescriptionId);
	}
}
