using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.BLL.DTO.Visit
{
	public class CreateVisitDTO
	{
		[Required]
		public int DoctorId { get; set; }

		[Required]
		public int PatientId { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }
	}
}
