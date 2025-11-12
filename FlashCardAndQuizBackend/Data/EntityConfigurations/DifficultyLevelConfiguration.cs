using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder.ToTable("Difficulty_Levels");

            builder.HasKey(dl => dl.Level);

            builder.Property(dl => dl.Level)
                .IsRequired();

            builder.Property(dl => dl.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                Enum.GetValues<Difficulty>()
                    .Select((difficulty, index) => new DifficultyLevel
                    {
                        //Id = index + 1,
                        Level = difficulty,
                        Label = difficulty.ToString()
                    })
            );
        }
    }
}
