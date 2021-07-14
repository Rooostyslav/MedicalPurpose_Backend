using MedicalPurpose.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IMedicineRepository
	{
		Task<Medicine> AddAsync(Medicine medicine);

		Task<IEnumerable<Medicine>> FindAsync(Expression<Func<Medicine, bool>> expression);
	}
}
