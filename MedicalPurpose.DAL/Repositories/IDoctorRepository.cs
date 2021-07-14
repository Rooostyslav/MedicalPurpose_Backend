using MedicalPurpose.DAL.Entity;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IDoctorRepository
	{
		Task<Doctor> AddAsync(Doctor doctor);

		Task<Doctor> FindFirstOrDefaultAsync(Expression<Func<Doctor, bool>> expression);

		Task<Doctor> FindByIdAsync(int id);
	}
}
