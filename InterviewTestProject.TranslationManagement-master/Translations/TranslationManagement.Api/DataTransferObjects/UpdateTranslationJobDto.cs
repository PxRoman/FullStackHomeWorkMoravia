namespace TranslationManagement.Api.DataTransferObjects
{
    public class UpdateTranslationJobDto
    {
        public int JobId { get; set; }
        public int TranslatorId { get; set; }
        public string NewStatus { get; set; }
    }
}
