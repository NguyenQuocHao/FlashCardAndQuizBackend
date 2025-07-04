using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Data.EntityConfigurations
{
    public class RegisterLevelConfiguration : IEntityTypeConfiguration<RegisterLevel>
    {
        public void Configure(EntityTypeBuilder<RegisterLevel> builder)
        {
            builder.ToTable("Register_Levels");

            builder.HasKey(rl => rl.FormalityLevel);

            builder.Property(rl => rl.FormalityLevel)
                .IsRequired();
            
            builder.Property(rl => rl.Label)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                Enum.GetValues<Register>()
                .Select((register, index) => new RegisterLevel
                {
                    //Id = index + 1,
                    FormalityLevel = register,
                    Label = register.ToString(),
                })
            );
        }
    }
}
