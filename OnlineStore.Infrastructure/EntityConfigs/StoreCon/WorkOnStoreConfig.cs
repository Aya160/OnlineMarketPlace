using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Infrastructure.EntityConfigs.StoreCon
{
    public class WorkOnStoreConfig : IEntityTypeConfiguration<WorkOnStore>
    {
        public void Configure(EntityTypeBuilder<WorkOnStore> builder)
        {
            builder.HasKey(w => new { w.VenderId, w.StoreId });
            builder.HasOne(w => w.Vendor).WithOne(v => v.WorkOnStore)
                .HasForeignKey<Vendor>(v => v.WorkID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(w => w.Store).WithMany(s => s.WorksOnStore)
                .HasForeignKey(w => w.StoreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
