using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class WordTypeConfiguration : IEntityTypeConfiguration<WordTypeEntity>
    {
        public void Configure(EntityTypeBuilder<WordTypeEntity> builder)
        {
            builder.ToTable("Word_Types");

            builder.HasKey(dl => dl.Code);

            builder.Property(dl => dl.Code)
                .IsRequired();

            builder.Property(dl => dl.Type)
                .IsRequired();

            builder.HasData(
                Enum.GetValues<WordType>()
                    .Select((difficulty, index) => new WordTypeEntity
                    {
                        Code = difficulty,
                        Type = difficulty.ToString()
                    })
            );
        }
    }
}
