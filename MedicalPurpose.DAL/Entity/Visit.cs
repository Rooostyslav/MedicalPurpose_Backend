using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPurpose.DAL.Entity
{
	public class Visit
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		public int DoctorId { get; set; }

		public virtual Doctor Doctor { get; set; }

		[Required]
		[Column(Order = 3)]
		public int PatientId { get; set; }

		public virtual Patient Patient { get; set; }

		[Required]
		[Column(Order = 4)]
		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }
	}
}
