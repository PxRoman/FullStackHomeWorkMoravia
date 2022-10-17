using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TranslationManagement.Domain.Factories;
using TranslationManagement.Domain.Models;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;
using TranslationManagement.Domain.Ports.Outputs;
using TranslationManagement.Infrastructure.Adapters.TranslationJobs;

namespace TranslationManagement.UnitTest
{
    public class Tests
    {
        private readonly Mock<ITranslationJobRepository> _translationJobRepository = new Mock<ITranslationJobRepository>();

        private readonly Mock<ILogger<UpdateTranslationJob>> _loggerUpdate = new Mock<ILogger<UpdateTranslationJob>>();
        private IUpdateTranslationJob _updateTranslationJob;

        private readonly Mock<ILogger<CreateTranslationJob>> _loggerCreate = new Mock<ILogger<CreateTranslationJob>>();
        private ICreateTranslationJob _createTranslationJob;


        [SetUp]
        public void Setup()
        {
            var translationJob1 = TranslationJobFactory.CreateTranslationJob(0, 0.5, JobStatuses.Completed, "Roman");

            var translationsArray = new [] {translationJob1};

            _translationJobRepository.Setup(x => x.GetTranslationJobById(0)).ReturnsAsync(() => translationsArray[0]);

            _updateTranslationJob = new UpdateTranslationJob(_translationJobRepository.Object, _loggerUpdate.Object);
            _createTranslationJob = new CreateTranslationJob(_translationJobRepository.Object, _loggerCreate.Object);

        }

        [Test]
        public async Task CreateTranslationJob()
        {
            var translationJob1 = TranslationJobFactory.CreateTranslationJobDto(0, 0.5, JobStatuses.Completed.ToString(), "Roman");

            await _createTranslationJob.HandleAsync(translationJob1, new CancellationToken());

            Assert.Pass();
        }

        [Test]
        public async Task UpdateTranslationJob()
        {
            await _updateTranslationJob.HandleAsync(0, 0, JobStatuses.InProgress.ToString(), new CancellationToken());

            Assert.Pass();
        }
    }
}
