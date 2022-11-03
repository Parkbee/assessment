using Data.Models.Garage;
using Data.Models.Garage.Spot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Maps.Garage;

public class SpotMap : IEntityTypeConfiguration<GarageSpotModel>
{
    public void Configure(EntityTypeBuilder<GarageSpotModel> builder)
    {
        builder
            .ToTable("GarageSpots")
            .HasKey(px => px.Id);

        builder
            .Property(px => px.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(px => px.ExternalId)
            .HasColumnName("ExternalId")
            .IsRequired();

        builder
            .Property(px => px.CreatedAt)
            .HasColumnName("CreatedAt")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(px => px.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .ValueGeneratedOnUpdate()
            .IsRequired();

        builder
            .Property(px => px.Identifier)
            .HasColumnName("Identifier");

        builder
            .Property(px => px.Details)
            .HasColumnName("Details");

        builder
            .Property(px => px.IsAvailable)
            .HasColumnName("IsAvailable")
            .HasConversion(
                px => px ? "True" : "False",
                px => px.Equals("True"))
            .IsRequired();
    }
}