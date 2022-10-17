using System;
using System.Threading;
using System.Threading.Tasks;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using TranslationManagement.Domain.DataTransferObjects;
using TranslationManagement.Domain.Factories;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;
using TranslationManagement.Domain.Ports.Outputs;
using TranslationManagement.Infrastructure.Definitions;

namespace TranslationManagement.Infrastructure.Adapters.TranslationJobs
{
    public class CreateTranslationJob : ICreateTranslationJob
    {
        private readonly ITranslationJobRepository _repository;
        private readonly ILogger<CreateTranslationJob> _logger;

        public CreateTranslationJob(ITranslationJobRepository repository, ILogger<CreateTranslationJob> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task HandleAsync(TranslationJobDto translationJobDto, CancellationToken cancellationToken)
        {
            var translationJob = TranslationJobFactory.TranslationJobDtoToTranslationJob(translationJobDto);

            translationJob.Price = translationJob.OriginalContent.Length * TranslationDefinitions.PriceParCharacter;

            await _repository.CreateTranslationJobAsync(translationJob, cancellationToken);

            var notificationSvc = new UnreliableNotificationService();

            var sendNotificationSucceed = false;
            var retryAmount = 0;

            while (!sendNotificationSucceed && retryAmount < TranslationDefinitions.RetryLimit)
            {
                try
                {
                    sendNotificationSucceed = await notificationSvc.SendNotification("Job created: " + translationJob.Id);
                }
                catch (Exception e)
                {
                    retryAmount++;
                }
            }

            _logger.LogInformation("New job notification sent");
        }
    }
}
