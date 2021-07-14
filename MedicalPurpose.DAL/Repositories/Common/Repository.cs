using MedicalPurpose.DAL.EF;
using System.Threading.Tasks;

namespace MedicalPurpose.DAL.Repositories.Common
{
	public class Repository<TEntity> where TEntity : class
	{
		private readonly MedicalPurposeContext _context;

		public Repository(MedicalPurposeContext medicalPurposeContext)
		{
			_context = medicalPurposeContext;
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			var entityEntry = await _context.AddAsync(entity);
			return entityEntry.Entity;
		}
	}
}
