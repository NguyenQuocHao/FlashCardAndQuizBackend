using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class FrequencyLevelConfiguration : IEntityTypeConfiguration<FrequencyLevel>
    {
        public void Configure(EntityTypeBuilder<FrequencyLevel> builder)
        {
            builder.ToTable("Frequency_Levels");

            builder.HasKey(fl => fl.Level);

            builder.Property(fl => fl.Level)
                .IsRequired();

            builder.Property(fl => fl.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                Enum.GetValues<Frequency>()
                    .Select((frequency, index) => new FrequencyLevel
                    {
                        //Id = index + 1,
                        Level = frequency,
                        Label = frequency.ToString()
                    })
            );
        }
    }
}
