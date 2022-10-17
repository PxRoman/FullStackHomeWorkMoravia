using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Ports.Outputs;
using TranslationManagement.Infrastructure.Database;

namespace TranslationManagement.Infrastructure.Repositories
{
    public class TranslationJobRepository : ITranslationJobRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TranslationJob> _translationJobs;

        public TranslationJobRepository(AppDbContext context)
        {
            _context = context;
            _translationJobs = _context.Set<TranslationJob>();
        }

        public IQueryable<TranslationJob> Query()
        {
            return _translationJobs.AsQueryable();
        }

        public async Task<TranslationJob> GetTranslationJobById(int jobId)
        {
            return await _translationJobs.Where(t => t.Id == jobId).FirstOrDefaultAsync();
        }

        public async Task UpdateTranslationJobAsync(TranslationJob translationJob, CancellationToken cancellationToken)
        {
            _translationJobs.Update(translationJob);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateTranslationJobAsync(TranslationJob translationJob, CancellationToken cancellationToken)
        {
            await _translationJobs.AddAsync(translationJob, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
