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
	public class MedicineRepository : Repository<Medicine>, IMedicineRepository
	{
		private readonly MedicalPurposeContext _context;

		public MedicineRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<IEnumerable<Medicine>> FindAsync(Expression<Func<Medicine, bool>> expression)
		{
			var query = GetQueryWithIncludes();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return await query.ToListAsync();
		}

		private IQueryable<Medicine> GetQueryWithIncludes()
		{
			return _context.Medicines.Include(m => m.MedicinePrescriptions);
		}
	}
}
