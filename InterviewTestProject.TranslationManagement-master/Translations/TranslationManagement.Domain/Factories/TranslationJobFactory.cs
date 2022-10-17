using System;
using TranslationManagement.Domain.DataTransferObjects;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Models;

namespace TranslationManagement.Domain.Factories
{
    public static class TranslationJobFactory
    {
        public static TranslationJob CreateTranslationJob(int id = 0, double price = 0, JobStatuses jobStatus = 0, string customerName = "", string originalContent = "", string translatedContent = "")
        {
            return new TranslationJob
            {
                Id = id,
                Price = price,
                Status = jobStatus,
                CustomerName = customerName,
                OriginalContent = originalContent,
                TranslatedContent = translatedContent
            };
        }

        public static TranslationJobDto CreateTranslationJobDto(int id = 0, double price = 0, string jobStatus = "", string customerName = "", string originalContent = "", string translatedContent = "")
        {
            return new TranslationJobDto
            {
                Id = id,
                Price = price,
                Status = jobStatus,
                CustomerName = customerName,
                OriginalContent = originalContent,
                TranslatedContent = translatedContent
            };
        }

        public static TranslationJob TranslationJobDtoToTranslationJob(TranslationJobDto translationJobDto)
        {
            if (Enum.TryParse<JobStatuses>(translationJobDto.Status, out var parsedStatus))
            {
                return CreateTranslationJob(translationJobDto.Id, translationJobDto.Price, parsedStatus, translationJobDto.CustomerName, translationJobDto.OriginalContent, translationJobDto.TranslatedContent);
            }

            throw new Exception($"Can not parse job status: {translationJobDto.Status}");
        }

        public static TranslationJobDto TranslationJobToTranslationJobDto(TranslationJob translationJob)
        {
            return CreateTranslationJobDto(translationJob.Id, translationJob.Price, translationJob.Status.ToString(), translationJob.CustomerName, translationJob.OriginalContent, translationJob.TranslatedContent);
        }
    }
}
