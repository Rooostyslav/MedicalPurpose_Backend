using AutoMapper;
using MedicalPurpose.BLL.DTO.Prescription;
using MedicalPurpose.BLL.DTO.Visit;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class PrescriptionService : IPrescriptionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMedicineService _medicineService;
		private readonly IQRCodeService _qRCodeService;
		private readonly IVisitService _visitService;

		public PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper,
			IMedicineService medicineService,
			IQRCodeService qRCodeService,
			IVisitService visitService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_medicineService = medicineService;
			_qRCodeService = qRCodeService;
			_visitService = visitService;
		}

		public async Task<PrescriptionDTO> CreateAsync(CreatePrescriptionDTO prescription)
		{
			await _visitService.CreateAsync(new CreateVisitDTO
			{
				DoctorId = prescription.DoctorId,
				PatientId = prescription.PatientId,
				DateTime = DateTime.Now
			});
			await _unitOfWork.SaveAsync();

			var prescriptionMapped = _mapper.Map<Prescription>(prescription);
			var result = await _unitOfWork.Prescriptions.AddAsync(prescriptionMapped);
			await _unitOfWork.SaveAsync();

			if (result != null)
			{
				foreach (var medicine in prescription.Medicines)
				{
					var medicinePrescription = new MedicinePrescription
					{
						MedicineId = medicine.Id,
						PrescriptionId = result.Id,
						AmountPieces = medicine.Amount
					};

					await _unitOfWork.MedicinePrescriptions
						.AddAsync(medicinePrescription);
					await _unitOfWork.SaveAsync();
				}

				var mappedResult = _mapper.Map<PrescriptionDTO>(result);
				await _qRCodeService.GenerateQRCodeAsync(mappedResult);

				mappedResult.Medicines =
					await _medicineService.FindByPrescriptionAsync(result.Id);
				return mappedResult;
			}

			return null; 
		}

		public async Task<PrescriptionDTO> FindByIdAsync(int prescriptionId)
		{
			var prescription = await _unitOfWork.Prescriptions.FindByIdAsync(prescriptionId);
			var mappedPrescription = _mapper.Map<PrescriptionDTO>(prescription);

			mappedPrescription.Medicines = await _medicineService.FindByPrescriptionAsync(prescriptionId);
			return mappedPrescription;
		}

		public async Task<IEnumerable<PrescriptionDTO>> FindByDoctorAsync(int doctorId)
		{
			return await FindByExpressionAsync(p => p.DoctorId == doctorId);
		}

		public async Task<IEnumerable<PrescriptionDTO>> FindByPatientAsync(int patientId)
		{
			return await FindByExpressionAsync(p => p.PatientId == patientId);
		}

		private async Task<IEnumerable<PrescriptionDTO>> FindByExpressionAsync(
			Expression<Func<Prescription, bool>> expression)
		{
			var prescriptions = await _unitOfWork.Prescriptions.FindAsync(expression);
			var mappedPrescriptions = _mapper.Map<IEnumerable<PrescriptionDTO>>(prescriptions);

			foreach (var prescription in mappedPrescriptions)
			{
				prescription.Medicines = await _medicineService.FindByPrescriptionAsync(prescription.Id);
			}

			return mappedPrescriptions;
		}
	}
}
