using MedicalPurpose.DAL.Entity.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalPurpose.DAL.Entity
{
	public class Patient : BaseUser
	{
		public virtual ICollection<Visit> Visits { get; set; }

		public virtual ICollection<Prescription> Prescriptions { get; set; }

		public Patient()
		{
			Visits = new Collection<Visit>();
			Prescriptions = new Collection<Prescription>();
		}
	}
}
