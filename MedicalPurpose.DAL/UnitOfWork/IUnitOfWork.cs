using MedicalPurpose.DAL.Repositories;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IDoctorRepository Doctors { get; }

		IPatientRepository Patients { get; }

		IVisitRepository Visits { get; }

		IPrescriptionRepository Prescriptions { get; }

		IMedicineRepository Medicines { get; }

		IMedicinePrecriptionRepository MedicinePrescriptions { get; }

		Task SaveAsync();
	}
}
