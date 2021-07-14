using MedicalPurpose.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MedicalPurpose.DAL.EF
{
	public class MedicalPurposeContext : DbContext
	{
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Visit> Visits { get; set; }
		public DbSet<Prescription> Prescriptions { get; set; }
		public DbSet<Medicine> Medicines { get; set; }
		public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }

		public MedicalPurposeContext(DbContextOptions<MedicalPurposeContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
