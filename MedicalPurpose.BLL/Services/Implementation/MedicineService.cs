using AutoMapper;
using MedicalPurpose.BLL.DTO.Medicine;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.Repositories;
using MedicalPurpose.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class MedicineService : IMedicineService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMedicinePrecriptionRepository _medicinePrecriptions;

		public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_medicinePrecriptions = _unitOfWork.MedicinePrescriptions;
		}

		public async Task<MedicineDTO> CreateAsync(CreateMedicineDTO medicine)
		{
			var medicineMapped = _mapper.Map<Medicine>(medicine);
			var result = await _unitOfWork.Medicines.AddAsync(medicineMapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<MedicineDTO>(result);
		}

		public async Task<IEnumerable<MedicineDTO>> FindAllAsync()
		{
			var medicines = await _unitOfWork.Medicines.FindAsync(null);
			return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
		}

		public async Task<IEnumerable<PrescriptionMedicineDTO>> FindByPrescriptionAsync(int prescriptionId)
		{
			var medicines = await _medicinePrecriptions.FindByPrescriptionAsync(prescriptionId);

			var uniqueMedicines = medicines.SelectMany(m => medicines.Where(e => e.MedicineId == m.MedicineId))
				.GroupBy(b => b.MedicineId)
				.Select(b => b.First())
				.Select(b => b.Medicine);

			var resultMedicines = _mapper.Map<IEnumerable<PrescriptionMedicineDTO>>(uniqueMedicines);
			foreach(var medicine in resultMedicines)
			{
				medicine.Amount = medicines.Where(m => m.MedicineId == medicine.Id).Sum(m => m.AmountPieces);
				medicine.TotalPrice = medicine.PriceForOne * medicine.Amount;
			}

			return resultMedicines;
		}
	}
}
