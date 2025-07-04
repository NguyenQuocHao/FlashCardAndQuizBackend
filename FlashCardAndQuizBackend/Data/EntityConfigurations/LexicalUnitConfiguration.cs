using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class LexicalUnitConfiguration : IEntityTypeConfiguration<LexicalUnit>
    {
        public void Configure(EntityTypeBuilder<LexicalUnit> builder)
        {
            builder.ToTable("Lexical_Units");

            builder.HasKey(w => w.Id);

            builder.HasIndex(w => w.Text).IsUnique();
            
            builder.Property(w => w.Text)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
