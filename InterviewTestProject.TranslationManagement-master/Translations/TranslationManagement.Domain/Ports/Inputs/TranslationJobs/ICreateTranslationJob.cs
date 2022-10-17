using System.Threading;
using System.Threading.Tasks;
using TranslationManagement.Domain.DataTransferObjects;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Domain.Ports.Inputs.TranslationJobs
{
    public interface ICreateTranslationJob
    {
        Task HandleAsync(TranslationJobDto translationJobDto, CancellationToken cancellationToken);
    }
}
