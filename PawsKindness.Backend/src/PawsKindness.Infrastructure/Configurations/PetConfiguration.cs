using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.Volunteers;
using PawsKindness.Domain.Models.Volunteers.Pets;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.Property(p => p.Description)
            .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
            .IsRequired(false);

        builder.Property(p => p.Species)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.Property(p => p.BreedName)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.Property(p => p.Color)
           .HasMaxLength(Constants.LOW_TEXT_LENGTH)
           .IsRequired(false);

        builder.Property(p => p.HealthInfo)
          .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.Property(p => p.Address)
          .HasMaxLength(Constants.HIGH_TEXT_LENGTH);

        builder.Property(p => p.PhoneNumber)
            .IsRequired(false);

        builder.OwnsOne(x => x.Details, x =>
        {
            x.ToJson();
            x.OwnsMany(r => r.Requisites, r =>
            {
                r.Property(p => p.Description)
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                r.Property(p => p.Description)
                    .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                    .IsRequired(false);
            });
        });

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("pet_id");
    }
}

