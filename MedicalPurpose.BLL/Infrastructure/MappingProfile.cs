using AutoMapper;
using MedicalPurpose.BLL.DTO.Doctor;
using MedicalPurpose.BLL.DTO.Medicine;
using MedicalPurpose.BLL.DTO.Patient;
using MedicalPurpose.BLL.DTO.Prescription;
using MedicalPurpose.BLL.DTO.Visit;
using MedicalPurpose.DAL.Entity;

namespace MedicalPurpose.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateDoctorDTO, Doctor>();
			CreateMap<Doctor, DoctorDTO>();

			CreateMap<CreatePatientDTO, Patient>();
			CreateMap<Patient, PatientDTO>();

			CreateMap<CreateVisitDTO, Visit>();
			CreateMap<Visit, VisitDTO>();

			CreateMap<CreateMedicineDTO, Medicine>();
			CreateMap<Medicine, MedicineDTO>();
			CreateMap<Medicine, PrescriptionMedicineDTO>();

			CreateMap<CreatePrescriptionDTO, Prescription>();
			CreateMap<Prescription, PrescriptionDTO>();

		}
	}
}
