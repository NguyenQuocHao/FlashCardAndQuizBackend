using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class ImportanceLevelConfiguration : IEntityTypeConfiguration<ImportanceLevel>
    {
        public void Configure(EntityTypeBuilder<ImportanceLevel> builder)
        {
            builder.ToTable("Importance_Levels");

            builder.HasKey(il => il.Level);

            builder.Property(il => il.Level)
                .IsRequired();

            builder.Property(il => il.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                Enum.GetValues<Importance>()
                    .Select((importance, index) => new ImportanceLevel
                    {
                        //Id = index + 1,
                        Level = importance,
                        Label = importance.ToString()
                    })
            );
        }
    }
}
