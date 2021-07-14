using MedicalPurpose.DAL.EF;
using MedicalPurpose.DAL.Repositories;
using MedicalPurpose.DAL.Repositories.Implementation;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MedicalPurposeContext _context;
		private IDoctorRepository _doctorRepository;
		private IPatientRepository _patientRepository;
		private IVisitRepository _visitRepository;
		private IPrescriptionRepository _prescriptionRepository;
		private IMedicineRepository _medicineRepository;
		private IMedicinePrecriptionRepository _medicinePrecriptionRepository;

		public UnitOfWork(MedicalPurposeContext medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public IDoctorRepository Doctors
		{
			get
			{
				if (_doctorRepository == null)
				{
					_doctorRepository = new DoctorRepository(_context);
				}

				return _doctorRepository;
			}
		}

		public IPatientRepository Patients
		{
			get
			{
				if (_patientRepository == null)
				{
					_patientRepository = new PatientRepository(_context);
				}

				return _patientRepository;
			}
		}

		public IVisitRepository Visits
		{
			get
			{
				if (_visitRepository == null)
				{
					_visitRepository = new VisitRepository(_context);
				}

				return _visitRepository;
			}
		}

		public IPrescriptionRepository Prescriptions
		{
			get
			{
				if (_prescriptionRepository == null)
				{
					_prescriptionRepository = new PrescriptionRepository(_context);
				}

				return _prescriptionRepository;
			}
		}

		public IMedicineRepository Medicines
		{
			get
			{
				if (_medicineRepository == null)
				{
					_medicineRepository = new MedicineRepository(_context);
				}

				return _medicineRepository;
			}
		}

		public IMedicinePrecriptionRepository MedicinePrescriptions
		{
			get
			{
				if (_medicinePrecriptionRepository == null)
				{
					_medicinePrecriptionRepository = new MedicinePrecriptionRepository(_context);
				}

				return _medicinePrecriptionRepository;
			}
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
