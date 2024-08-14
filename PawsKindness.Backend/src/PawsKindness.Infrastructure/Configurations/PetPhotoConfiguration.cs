using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.Volunteers.Pets;

namespace PawsKindness.Infrastructure.Configurations
{
    public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
    {
        public void Configure(EntityTypeBuilder<PetPhoto> builder)
        {
            builder.ToTable(PetPhoto.TABLE_NAME);

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Path)
                .IsRequired();

            builder.Property(x => x.IsMain)
                .IsRequired();
        }
    }
}
