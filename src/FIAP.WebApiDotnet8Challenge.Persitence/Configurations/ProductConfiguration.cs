using FIAP.WebApiDotnet8Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.WebApiDotnet8Challenge.Repositories.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("int").HasColumnName("id").UseIdentityColumn();
        builder.Property(p => p.Code).HasColumnType("varchar(50)").HasColumnName("code").IsRequired();
        builder.Property(p => p.Description).HasColumnType("varchar(255)").HasColumnName("description").IsRequired();
        builder.Property(p => p.Brand).HasColumnType("varchar(100)").HasColumnName("brand").IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(10,2)").HasColumnName("price").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnType("timestamp").HasColumnName("created_at").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnType("timestamp").HasColumnName("updated_at").IsRequired();
    }
}