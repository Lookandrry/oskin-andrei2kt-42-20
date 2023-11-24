using Microsoft.EntityFrameworkCore;
using OskinAndreiKt_42_20.Database;
using OskinAndreiKt_42_20.Filters;
using OskinAndreiKt_42_20.Models;

namespace OskinAndreiKt_42_20.Interfaces
{

    public interface IPrepodService
    {
        public Task<Prepod[]> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken);
       // public Task<Prepod[]> GetPrepodsByNameAsync(PrepodNameFilter filter, CancellationToken cancellationToken);
    }
    public class PrepodService : IPrepodService
    {
        private readonly PrepodDbContext _dbContext;
        public PrepodService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Prepod[]> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Kafedra.KafedraName == filter.KafedraName).ToArrayAsync(cancellationToken);

            return prepod;
        }
      /*
        public Task<Prepod[]> GetPrepodsByNameAsync(PrepodNameFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return prepod;
        } 
      */
    }
}