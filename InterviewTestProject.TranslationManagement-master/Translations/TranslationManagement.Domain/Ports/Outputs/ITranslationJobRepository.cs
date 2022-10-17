using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Domain.Ports.Outputs
{
    public interface ITranslationJobRepository
    {
        IQueryable<TranslationJob> Query();
        Task<TranslationJob> GetTranslationJobById(int jobId);
        Task UpdateTranslationJobAsync(TranslationJob translationJob, CancellationToken cancellationToken);
        Task CreateTranslationJobAsync(TranslationJob translationJob, CancellationToken cancellationToken);
    }
}
