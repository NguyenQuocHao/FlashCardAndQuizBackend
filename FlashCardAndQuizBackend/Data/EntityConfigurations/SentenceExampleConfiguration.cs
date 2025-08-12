using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class SentenceExampleConfiguration : IEntityTypeConfiguration<SentenceExample>
    {
        public void Configure(EntityTypeBuilder<SentenceExample> builder)
        {
            builder.ToTable("Sentence_Examples");

            builder.HasKey(se => se.Id);

            builder.Property(se => se.Sentence)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasMany(se => se.Meanings)
                .WithMany(m => m.SentenceExamples)
                .UsingEntity("Meanings_SentenceExamples");

            //builder.HasOne(se => se.Meaning)
            //    .WithMany(m => m.SentenceExamples)
            //    .HasForeignKey(se => se.MeaningId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
