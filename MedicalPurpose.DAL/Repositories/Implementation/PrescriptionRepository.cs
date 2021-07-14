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
	public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
	{
		private readonly MedicalPurposeContext _context;

		public PrescriptionRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<IEnumerable<Prescription>> FindAsync(Expression<Func<Prescription, bool>> expression)
		{
			var query = GetQueryWithIncludes();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return await query.ToListAsync();
		}


		public async Task<Prescription> FindByIdAsync(int id)
		{
			return await GetQueryWithIncludes()
				.FirstOrDefaultAsync(c => c.Id == id);
		}

		private IQueryable<Prescription> GetQueryWithIncludes()
		{
			return _context.Prescriptions
				.Include(p => p.MedicinePrescriptions)
				.Include(p => p.Patient)
				.Include(p => p.Doctor);
		}
	}
}
