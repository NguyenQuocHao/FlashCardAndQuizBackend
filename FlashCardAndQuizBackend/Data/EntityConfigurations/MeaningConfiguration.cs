using FlashCardAndQuizBackend.Enums;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class MeaningConfiguration : IEntityTypeConfiguration<Meaning>
    {
        public void Configure(EntityTypeBuilder<Meaning> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(m => m.Note)
                .HasMaxLength(1000);

            // Configure relationships
            //builder.HasOne(m => m.Difficulty)
            //    .WithMany()
            //    .HasForeignKey(m => m.DifficultyLevelId);

            //builder.HasOne(m => m.Frequency)
            //    .WithMany()
            //    .HasForeignKey(m => m.FrequencyLevelId);

            //builder.HasOne(m => m.Importance)
            //    .WithMany()
            //    .HasForeignKey(m => m.ImportanceLevelId);

            //builder.HasOne(m => m.Register)
            //    .WithMany()
            //    .HasForeignKey(m => m.RegisterLevelId);

            builder.HasOne(m => m.LexicalUnit)
                .WithMany(lu => lu.Meanings)
                .HasForeignKey(lu => lu.LexicalUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set default values for properties
            builder.Property(m => m.DifficultyLevel)
                .HasDefaultValue(Difficulty.Moderate);

            builder.Property(m => m.FrequencyLevel)
                .HasDefaultValue(Frequency.Common);

            builder.Property(m => m.ImportanceLevel)
                .HasDefaultValue(Importance.Medium);

            builder.Property(m => m.RegisterLevel)
                .HasDefaultValue(Register.Consultative);

            builder.HasMany<Tag>()
                .WithMany();
        }
    }
}
