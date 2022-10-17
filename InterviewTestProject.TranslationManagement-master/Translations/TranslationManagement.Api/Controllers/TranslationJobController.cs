using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Api.DataTransferObjects;
using TranslationManagement.Domain.DataTransferObjects;
using TranslationManagement.Domain.Factories;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
        [HttpGet]
        public async Task<TranslationJobDto[]> GetJobs(
            [FromServices] IGetTranslationJobsDtoArray getTranslationJobsArray
            )
        {
            return await getTranslationJobsArray.HandleAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(
            [FromServices] ICreateTranslationJob createTranslationJob,
            TranslationJobDto translationJobDto,
            CancellationToken cancellationToken)
        {
            try
            {
                await createTranslationJob.HandleAsync(translationJobDto, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobWithFile(
            [FromServices] ICreateTranslationJob createTranslationJob,
            IFormFile file,
            string customer,
            CancellationToken cancellationToken)
        {
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = await reader.ReadToEndAsync();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(await reader.ReadToEndAsync());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("Unsupported file");
            }

            var newJob = TranslationJobFactory.CreateTranslationJobDto(originalContent: content, customerName: customer);

            await createTranslationJob.HandleAsync(newJob, cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobStatus(
            [FromServices] IUpdateTranslationJob updateTranslationJob,
            UpdateTranslationJobDto updateDto,
            CancellationToken cancellationToken)
        {
            try
            {
                await updateTranslationJob.HandleAsync(updateDto.JobId, updateDto.TranslatorId, updateDto.NewStatus, cancellationToken);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
