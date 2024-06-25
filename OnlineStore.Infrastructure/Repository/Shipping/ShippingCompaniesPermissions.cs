using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.Shipping
{
    public class ShippingCompaniesPermissions<T> : IGenaricRepository<T> where T : ShippingCompaniesPermissions
    {
        private readonly ApplicationDbContext context;

        public ShippingCompaniesPermissions(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.ShippingCompaniesPermissions.Include(s => s.ShippingCompanies).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.ShippingCompaniesPermissions.Include(s => s.ShippingCompanies).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.ShippingCompaniesPermissions.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.ShippingCompaniesPermissions.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            ShippingCompaniesPermissions entity = await context.ShippingCompaniesPermissions.FindAsync(id);
            entity!.IsDeleted = true;
            context.ShippingCompaniesPermissions.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
