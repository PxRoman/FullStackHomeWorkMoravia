using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Models;

namespace TranslationManagement.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TranslationJob> TranslationJobs { get; set; }
        public DbSet<Translator> Translators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<TranslationJob>().HasData(
                new{ Id=1, CustomerName="Roman", Status=JobStatuses.New, OriginalContent="OriginalContent", TranslatedContent="TranslatedContent", Price=0.5 },
                new{ Id=2, CustomerName="Michal", Status=JobStatuses.InProgress, OriginalContent="OriginalContent", TranslatedContent="TranslatedContent", Price=0.3 }
                );
        }
    }
}
