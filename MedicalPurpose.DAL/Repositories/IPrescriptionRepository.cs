using MedicalPurpose.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IPrescriptionRepository
	{
		Task<Prescription> AddAsync(Prescription prescription);

		Task<Prescription> FindByIdAsync(int id);

		Task<IEnumerable<Prescription>> FindAsync(Expression<Func<Prescription, bool>> expression);
	}
}
