using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalPurpose.DAL.Entity
{
	public class MedicinePrescription
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int MedicineId { get; set; }

		public virtual Medicine Medicine { get; set; }

		public int PrescriptionId { get; set; }

		public virtual Prescription Prescription { get; set; }

		public int AmountPieces { get; set; }
	}
}
