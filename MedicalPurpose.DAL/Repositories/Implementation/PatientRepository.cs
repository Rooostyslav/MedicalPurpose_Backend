using MedicalPurpose.DAL.EF;
using MedicalPurpose.DAL.Entity;
using MedicalPurpose.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories.Implementation
{
	public class PatientRepository : Repository<Patient>, IPatientRepository
	{
		private readonly MedicalPurposeContext _context;

		public PatientRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<IEnumerable<Patient>> FindAsync(Expression<Func<Patient, bool>> expression)
		{
			var query = GetQueryWithIncludes();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return await query.ToListAsync();
		}

		public async Task<Patient> FindByIdAsync(int id)
		{
			return await GetQueryWithIncludes()
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<Patient> FindFirstOrDefaultAsync(Expression<Func<Patient, bool>> expression)
		{
			return await GetQueryWithIncludes()
			.FirstOrDefaultAsync(expression);
		}

		private IQueryable<Patient> GetQueryWithIncludes()
		{
			return _context.Patients
				.Include(p => p.Prescriptions)
				.Include(p => p.Visits);
		}
	}
}
