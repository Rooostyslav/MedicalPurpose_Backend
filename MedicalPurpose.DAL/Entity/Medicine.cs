using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPurpose.DAL.Entity
{
	public class Medicine
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Column(Order = 3)]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Column(Order = 4)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Instruction { get; set; }

		[Required]
		[Column(Order = 5)]
		public double PriceForOne { get; set; }

		public virtual ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }

		public Medicine()
		{
			MedicinePrescriptions = new Collection<MedicinePrescription>();
		}
	}
}
