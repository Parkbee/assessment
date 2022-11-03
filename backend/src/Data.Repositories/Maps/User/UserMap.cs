using Data.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Maps.User;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder
            .ToTable("Users")
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
            .Property(px => px.LicensePlate)
            .HasColumnName("LicensePlate")
            .IsRequired();
    }
}