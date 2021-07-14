using AutoMapper;
using MedicalPurpose.BLL.DTO.Visit;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class VisitService : IVisitService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public VisitService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<VisitDTO> CreateAsync(CreateVisitDTO visit)
		{
			var visitMapped = _mapper.Map<Visit>(visit);
			var result = await _unitOfWork.Visits.AddAsync(visitMapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<VisitDTO>(result);
		}

		public async Task<IEnumerable<VisitDTO>> FindByDoctorAsync(int doctorId)
		{
			var visits = await _unitOfWork.Visits.FindAsync(v => v.DoctorId == doctorId);
			return _mapper.Map<IEnumerable<VisitDTO>>(visits);
		}

		public async Task<IEnumerable<VisitDTO>> FindByPatientAsync(int patientId)
		{
			var visits = await _unitOfWork.Visits.FindAsync(v => v.PatientId == patientId);
			return _mapper.Map<IEnumerable<VisitDTO>>(visits);
		}
	}
}
