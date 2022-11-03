using Data.Models.ParkingSession;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Maps.ParkingSession;

public class ParkingSessionMap : IEntityTypeConfiguration<ParkingSessionModel>
{
    public void Configure(EntityTypeBuilder<ParkingSessionModel> builder)
    {
        builder
            .ToTable("ParkingSessions")
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
            .HasOne(px => px.GarageSpot);

        builder
            .HasOne(px => px.User);

        builder
            .Property(px => px.Start)
            .HasColumnName("StartDate")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(px => px.Stop)
            .HasColumnName("StopDate");
    }
}