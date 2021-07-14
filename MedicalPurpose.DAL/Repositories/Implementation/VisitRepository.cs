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
	public class VisitRepository : Repository<Visit>, IVisitRepository
	{
		private readonly MedicalPurposeContext _context;

		public VisitRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<IEnumerable<Visit>> FindAsync(Expression<Func<Visit, bool>> expression)
		{
			var query = GetQueryWithIncludes();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return await query.ToListAsync();
		}

		private IQueryable<Visit> GetQueryWithIncludes()
		{
			return _context.Visits
				.Include(p => p.Doctor)
				.Include(p => p.Patient);
		}
	}
}
