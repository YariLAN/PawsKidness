using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.Species.Breeds;
using PawsKindness.Domain.Models.SpeciesControl.Entities;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                id => BreedId.Create(id));

        builder.Property(x => x.Name)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);
    }
}
