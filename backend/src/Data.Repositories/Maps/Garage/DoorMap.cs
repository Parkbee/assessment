using Data.Models.Garage;
using Data.Models.Garage.Door;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Maps.Garage;

public class DoorMap : IEntityTypeConfiguration<GarageDoorModel>
{
    public void Configure(EntityTypeBuilder<GarageDoorModel> builder)
    {
        builder
            .ToTable("GarageDoors")
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
            .Property(px => px.IsOpen)
            .HasColumnName("IsOpen")
            .HasConversion(
                px => px ? "True" : "False",
                px => px.Equals("True"))
            .IsRequired();

        builder
            .HasOne(px => px.Garage)
            .WithMany(px => px.Doors);
    }
}