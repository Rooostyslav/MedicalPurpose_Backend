using MedicalPurpose.DAL.EF;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories.Implementation
{
	public class DoctorRepository : Repository<Doctor>, IDoctorRepository
	{
		private readonly MedicalPurposeContext _context;

		public DoctorRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<Doctor> FindByIdAsync(int id)
		{
			return await GetQueryWithIncludes()
				.FirstOrDefaultAsync(d => d.Id == id);
		}

		public async Task<Doctor> FindFirstOrDefaultAsync(Expression<Func<Doctor, bool>> expression)
		{
			return await GetQueryWithIncludes()
				.FirstOrDefaultAsync(expression);
		}

		private IQueryable<Doctor> GetQueryWithIncludes()
		{
			return _context.Doctors
				.Include(d => d.Prescriptions)
				.Include(d => d.Visits);
		}
	}
}
