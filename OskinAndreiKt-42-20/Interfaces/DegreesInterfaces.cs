using Microsoft.EntityFrameworkCore;
using OskinAndreiKt_42_20.Database;
using OskinAndreiKt_42_20.Filters;
using OskinAndreiKt_42_20.Models;

namespace OskinAndreiKt_42_20.Interfaces
{

    public interface IDegreesService
    {
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken);
    }

    public class DegreeService : IDegreesService
    {
        private readonly PrepodDbContext _dbContext;
        public DegreeService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByDegreeAsync(PrepodDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var degrees = _dbContext.Set<Prepod>().Where(w => w.Degree.DegreeId == filter.DegreeId).ToArrayAsync(cancellationToken);

            return degrees;
        }
    }
}
