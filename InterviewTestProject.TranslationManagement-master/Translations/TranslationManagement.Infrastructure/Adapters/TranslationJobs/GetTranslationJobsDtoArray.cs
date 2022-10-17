using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.DataTransferObjects;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Factories;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;
using TranslationManagement.Domain.Ports.Outputs;

namespace TranslationManagement.Infrastructure.Adapters.TranslationJobs
{
    public class GetTranslationJobsDtoArray : IGetTranslationJobsDtoArray
    {
        private readonly ITranslationJobRepository _repository;

        public GetTranslationJobsDtoArray(ITranslationJobRepository repository)
        {
            _repository = repository;
        }

        public  Task<TranslationJobDto[]> HandleAsync()
        {
            return _repository.Query()
                .Select(t => TranslationJobFactory.TranslationJobToTranslationJobDto(t))
                .ToArrayAsync();
        }
    }
}
