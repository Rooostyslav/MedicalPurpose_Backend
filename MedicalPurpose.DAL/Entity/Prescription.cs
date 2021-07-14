using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPurpose.DAL.Entity
{
	public class Prescription
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

		[Column(Order = 4)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		public virtual ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }

		public Prescription()
		{
			MedicinePrescriptions = new Collection<MedicinePrescription>();
		}
	}
}
