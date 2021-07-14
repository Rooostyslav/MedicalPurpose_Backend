using MedicalPurpose.DAL.Entity.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalPurpose.DAL.Entity
{
	public class Doctor : BaseUser
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Position { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string KindOfActivity { get; set; }

		public virtual ICollection<Visit> Visits { get; set; }

		public virtual ICollection<Prescription> Prescriptions { get; set; }

		public Doctor()
		{
			Visits = new Collection<Visit>();
			Prescriptions = new Collection<Prescription>();
		}
	}
}
