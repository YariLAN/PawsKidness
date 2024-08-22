using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.SpeciesControl;
using PawsKindness.Domain.Models.SpeciesControl.Ids;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                id => SpeciesId.Create(id));

        builder.Property(x => x.Name)
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        builder.HasMany(x => x.Breeds)
            .WithOne()
            .HasForeignKey("species_id");
    }
}
