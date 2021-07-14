using AutoMapper;
using MedicalPurpose.BLL.BusinessModels;
using MedicalPurpose.BLL.DTO.Doctor;
using MedicalPurpose.BLL.Infrastructure;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class DoctorService : IDoctorService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<DoctorDTO> CreateAsync(CreateDoctorDTO doctor)
		{
			var doctorMapped = _mapper.Map<Doctor>(doctor);
			doctorMapped.Password = Hash.CreateMD5(doctor.Password);

			var result = await _unitOfWork.Doctors.AddAsync(doctorMapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<DoctorDTO>(result);
		}

		public async Task<DoctorDTO> FindByIdAsync(int id)
		{
			var doctor = await _unitOfWork.Doctors.FindByIdAsync(id);
			return _mapper.Map<DoctorDTO>(doctor);
		}

		public async Task<DoctorDTO> FindByLoginAsync(Login login)
		{
			string passwordHash = Hash.CreateMD5(login.Password);
			var doctor = await _unitOfWork.Doctors
				.FindFirstOrDefaultAsync(d => d.Email == login.Email &&
					d.Password == passwordHash);
			return _mapper.Map<DoctorDTO>(doctor);
		}
	}
}
