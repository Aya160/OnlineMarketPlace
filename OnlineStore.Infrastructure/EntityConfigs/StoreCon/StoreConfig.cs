using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.EntityConfigs.General;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class StoreConfig : BaseConfig, IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasOne(s => s.Administrator).WithMany(a => a.Stores)
                .HasForeignKey(s => s.AdministratorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.WorksOnStore).WithOne(w => w.Store);
            builder.HasOne(s => s.StoreManager).WithOne(sm => sm.Store);
            builder.HasMany(s => s.IncludeCategories).WithOne(i => i.Store);
            builder.HasMany(s => s.ShippingCompanies).WithOne(c => c.Store);
            builder.HasMany(s => s.InvoiceOrders).WithOne(i => i.Store);
            builder.HasMany(s => s.SaleProducts).WithOne(c => c.Store);
            builder.HasMany(s => s.SaleCategories).WithOne(p => p.Store);
        }
    }
}
