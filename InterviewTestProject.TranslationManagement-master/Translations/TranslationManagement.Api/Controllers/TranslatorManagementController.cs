using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Infrastructure.Database;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    // this route feels weird as well
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase

    {
        public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

        private readonly ILogger<TranslatorManagementController> _logger;
        private AppDbContext _context;

        public TranslatorManagementController(IServiceScopeFactory scopeFactory, ILogger<TranslatorManagementController> logger)
        {
            _context = scopeFactory.CreateScope().ServiceProvider.GetService<AppDbContext>();
            _logger = logger;
        }

        [HttpGet]
        public Translator[] GetTranslators()
        {
            return _context.Translators.ToArray();
        }

        [HttpGet]
        public Translator[] GetTranslatorsByName(string name)
        {
            return _context.Translators.Where(t => t.Name == name).ToArray();
        }

        [HttpPost]
        public bool AddTranslator(Translator translator)
        {
            _context.Translators.Add(translator);
            return _context.SaveChanges() > 0;
        }

        [HttpPost]
        // Why return string
        public string UpdateTranslatorStatus(int Translator, string newStatus = "")
        {
            _logger.LogInformation("User status update request: " + newStatus + " for user " + Translator.ToString());
            if (TranslatorStatuses.Where(status => status == newStatus).Count() == 0)
            {
                throw new ArgumentException("unknown status");
            }

            var job = _context.Translators.Single(j => j.Id == Translator);
            job.Status = newStatus;
            _context.SaveChanges();

            return "updated";
        }
    }
}
