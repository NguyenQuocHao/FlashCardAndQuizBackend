using Microsoft.EntityFrameworkCore;
using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<LexicalUnit> LexicalUnits { get; set; }
        public DbSet<Meaning> Meanings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SentenceExample> SentenceExamples { get; set; }
        public DbSet<RegisterLevel> RegisterLevels { get; set; }
        public DbSet<FrequencyLevel> FrequencyLevels { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<ImportanceLevel> ImportanceLevels { get; set; }

        //public DbSet<QuizType> QuizTypes { get; set; }
        //public DbSet<QuizAttempt> QuizAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            //modelBuilder.Entity<QuizType>().HasKey(qt => qt.Id);
            //modelBuilder.Entity<QuizAttempt>().HasKey(qa => qa.Id);
        }
    }
}