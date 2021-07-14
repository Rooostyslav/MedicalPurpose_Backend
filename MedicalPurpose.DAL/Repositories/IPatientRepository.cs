using MedicalPurpose.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IPatientRepository
	{
		Task<Patient> AddAsync(Patient patient);

		Task<IEnumerable<Patient>> FindAsync(Expression<Func<Patient, bool>> expression);

		Task<Patient> FindFirstOrDefaultAsync(Expression<Func<Patient, bool>> expression);

		Task<Patient> FindByIdAsync(int id);
	}
}
