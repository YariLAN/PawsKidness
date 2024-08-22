using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.PetControl.Entities;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;
using PawsKindness.Domain.Models.Species.Breeds;
using PawsKindness.Domain.Models.SpeciesControl.Ids;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, id => PetId.Create(id));

        builder.Property(p => p.Name)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.Property(p => p.Description)
            .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
            .IsRequired(false);

        builder.ComplexProperty(p => p.Type, t =>
        {
            t.Property(t => t.SpeciesId)
                .HasConversion(x => x.Value, id => SpeciesId.Create(id));

            t.Property(t => t.BreedId)
                .IsRequired();
        });

        builder.Property(p => p.Color)
           .HasMaxLength(Constants.LOW_TEXT_LENGTH)
           .IsRequired(false);

        builder.Property(p => p.HealthInfo)
          .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.ComplexProperty(
            p => p.Address, ad =>
            {
                ad.Property(ad => ad.Country)
                  .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                ad.Property(ad => ad.City)
                  .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                ad.Property(ad => ad.PostCode)
                  .IsRequired();

                ad.Property(ad => ad.Street)
                  .HasMaxLength(Constants.LOW_TEXT_LENGTH)
                  .IsRequired(false);

                ad.Property(ad => ad.HouseNumber)
                  .HasMaxLength(Constants.MIN_LOW_TEXT_LENGTH)
                  .IsRequired(false);

                ad.Property(ad => ad.Apartment)
                  .HasMaxLength(Constants.MIN_LOW_TEXT_LENGTH)
                  .IsRequired(false);
            });

        builder.ComplexProperty(
            x => x.PhoneNumber, ph =>
            {
                ph.Property(ph => ph.Value)
                  .IsRequired()
                  .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            });

        builder.Property(p => p.BirthDay)
            .IsRequired();

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

