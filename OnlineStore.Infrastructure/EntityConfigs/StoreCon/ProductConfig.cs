using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class ProductConfig : BaseConfig, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category).WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.ContaintProducts).WithOne(c => c.Product);
            builder.HasMany(p => p.Images).WithOne(i => i.Product);
            builder.HasMany(p => p.InvoiceLines).WithOne(i => i.Product);
            builder.HasMany(p => p.InvoiceOrderLines).WithOne(i => i.Product);
            builder.HasOne(p => p.SaleProduct).WithMany(s => s.Products)
                .HasForeignKey(p => p.SaleProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.InvoiceOrderOnlineLines).WithOne(i => i.Product);
        }
    }
}
