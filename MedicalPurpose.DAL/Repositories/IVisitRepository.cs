using MedicalPurpose.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories
{
	public interface IVisitRepository
	{
		Task<Visit> AddAsync(Visit visit);

		Task<IEnumerable<Visit>> FindAsync(Expression<Func<Visit, bool>> expression);
	}
}
