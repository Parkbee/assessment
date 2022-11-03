using Data.Models.Garage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Maps.Garage;

public class GarageMap : IEntityTypeConfiguration<GarageModel>
{
    public void Configure(EntityTypeBuilder<GarageModel> builder)
    {
        builder
            .ToTable("Garages")
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
            .Property(px => px.Name)
            .HasColumnName("Name")
            .IsRequired();

        builder
            .Property(px => px.Description)
            .HasColumnName("Description")
            .IsRequired();

        builder
            .HasMany(px => px.Doors)
            .WithOne(door => door.Garage);
        
        builder
            .HasMany(px => px.Spots)
            .WithOne(spot => spot.Garage);
    }
}