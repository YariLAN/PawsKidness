using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PawsKindness.Domain.Models.Volunteers.Pets;
using PawsKindness.Domain.Models.Volunteers;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Surname)
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);

            builder.Property(x => x.MiddleName)
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                .IsRequired(false);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);

            builder.HasMany(x => x.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");

            builder.OwnsOne(x => x.Details, x =>
            {
                x.ToJson();
                x.OwnsMany(r => r.Requisites, r =>
                {
                    r.Property(p => p.Name)
                        .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                    r.Property(p => p.Description)
                        .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                        .IsRequired(false);
                });

                x.OwnsMany(s => s.SocialNetworks, s =>
                {
                    s.Property(x => x.Name)
                        .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                });
            });
        }
    }
}
