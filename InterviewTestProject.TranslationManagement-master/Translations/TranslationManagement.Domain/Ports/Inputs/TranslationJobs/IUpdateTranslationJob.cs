using System.Threading;
using System.Threading.Tasks;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Domain.Ports.Inputs.TranslationJobs
{
    public interface IUpdateTranslationJob
    {
        Task HandleAsync(int jobId, int translatorId, string newStatus, CancellationToken cancellationToken);
    }
}
