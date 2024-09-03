using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsKindness.Domain.Models.PetControl;
using PawsKindness.Domain.Models.PetControl.ValueObjects.Ids;
using PawsKindness.Domain.Shared;

namespace PawsKindness.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Value, 
                    id => VolunteerId.Create(id));

            builder.ComplexProperty(
                fullname => fullname.Name, fullname =>
                {
                    fullname.Property(f => f.Surname)
                     .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                    fullname.Property(f => f.Name)
                     .HasMaxLength(Constants.LOW_TEXT_LENGTH);

                    fullname.Property(f => f.MiddleName)
                        .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                }); 

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                .IsRequired(false);

            builder.ComplexProperty(
                x => x.PhoneNumber, ph =>
                {
                    ph.Property(ph => ph.Value)
                      .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                });

            builder.HasMany(x => x.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id")
                .OnDelete(DeleteBehavior.Cascade);

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
