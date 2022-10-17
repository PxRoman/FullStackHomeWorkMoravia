using System.Threading.Tasks;
using TranslationManagement.Domain.DataTransferObjects;

namespace TranslationManagement.Domain.Ports.Inputs.TranslationJobs
{
    public interface IGetTranslationJobsDtoArray
    {
        Task<TranslationJobDto[]> HandleAsync();
    }
}
