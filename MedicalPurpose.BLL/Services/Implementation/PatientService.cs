using AutoMapper;
using MedicalPurpose.BLL.BusinessModels;
using MedicalPurpose.BLL.DTO.Patient;
using MedicalPurpose.BLL.Infrastructure;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class PatientService : IPatientService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<PatientDTO> CreateAsync(CreatePatientDTO patient)
		{
			var patientMapped = _mapper.Map<Patient>(patient);
			patientMapped.Password = Hash.CreateMD5(patient.Password);

			var result = await _unitOfWork.Patients.AddAsync(patientMapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<PatientDTO>(result);
		}

		public async Task<IEnumerable<PatientDTO>> FindAllAsync()
		{
			var patients = await _unitOfWork.Patients.FindAsync(null);
			return _mapper.Map<IEnumerable<PatientDTO>>(patients);
		}

		public async Task<PatientDTO> FindByIdAsync(int id)
		{
			var patient = await _unitOfWork.Patients.FindByIdAsync(id);
			return _mapper.Map<PatientDTO>(patient);
		}

		public async Task<PatientDTO> FindByLoginAsync(Login login)
		{
			string passwordHash = Hash.CreateMD5(login.Password);
			var patient = await _unitOfWork.Patients
				.FindFirstOrDefaultAsync(p => p.Email == login.Email &&
					p.Password == passwordHash);
			return _mapper.Map<PatientDTO>(patient);
		}
	}
}
