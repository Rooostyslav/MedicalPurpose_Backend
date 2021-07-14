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
	public class MedicinePrecriptionRepository : Repository<MedicinePrescription>, IMedicinePrecriptionRepository
	{
		private readonly MedicalPurposeContext _context;

		public MedicinePrecriptionRepository(MedicalPurposeContext medicalPurposeContext)
			: base(medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public async Task<IEnumerable<MedicinePrescription>> FindByPrescriptionAsync(int prescriptionId)
		{
			var query = GetQueryWithIncludes()
				.Where(mp => mp.PrescriptionId == prescriptionId);

			return await query.ToListAsync();
		}

		private IQueryable<MedicinePrescription> GetQueryWithIncludes()
		{
			return _context.MedicinePrescriptions
				.Include(m => m.Medicine)
				.Include(m => m.Prescription);
		}
	}
}
