using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Models;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;
using TranslationManagement.Domain.Ports.Outputs;
using TranslationManagement.Infrastructure.Validators;

namespace TranslationManagement.Infrastructure.Adapters.TranslationJobs
{
    public class UpdateTranslationJob : IUpdateTranslationJob
    {
        private readonly ITranslationJobRepository _repository;
        private readonly ILogger<UpdateTranslationJob> _logger;

        public UpdateTranslationJob(ITranslationJobRepository repository,  ILogger<UpdateTranslationJob> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task HandleAsync(int jobId, int translatorId, string newStatus, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);

            if (!Enum.TryParse<JobStatuses>(newStatus, out var newJobStatus))
            {
                throw new Exception($"Invalid new status: {newStatus}");
            }

            var translationJob = await _repository.GetTranslationJobById(jobId);

            if (translationJob == null)
            {
                throw new Exception($"Translation job id: {jobId} not found");
            }

            if (!StatusChangeValidator.IsStatusChangeValid( translationJob.Status, newJobStatus))
            {
                throw new Exception($"Invalid status change from: {translationJob.Status}; to: {newJobStatus}");
            }

            translationJob.Status = newJobStatus;

            await _repository.UpdateTranslationJobAsync(translationJob, cancellationToken);
        }
    }
}
