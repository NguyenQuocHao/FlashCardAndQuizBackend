using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class FlashCardConfiguration : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.ToTable("Flash_Cards");

            builder.HasKey(w => w.Id);

            builder.HasOne<LexicalUnit>()
                .WithOne(lu => lu.FlashCard)
                .HasForeignKey<LexicalUnit>(fc => fc.FlashCardId);
        }
    }
}
