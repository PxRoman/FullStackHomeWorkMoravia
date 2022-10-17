namespace TranslationManagement.Domain.Entities
{
    public class Translator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // this is not even used
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        // this is not even used
        public string CreditCardNumber { get; set; }
    }
}
