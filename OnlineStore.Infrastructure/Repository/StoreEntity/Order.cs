using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repository.StoreEntity
{
    public class Order<T> : IGenaricRepository<T> where T : Order
    {
        private readonly ApplicationDbContext context;

        public Order(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => (IEnumerable<T>)await context.Orders.Include(o => o.DeliverCart).ToListAsync();

        public async Task<T> GetById(int id) => (T)await context.Orders.Include(o => o.DeliverCart).FirstOrDefaultAsync(v => v.Id == id);
        public async Task CreateAsync(T entity)
        {
            context.Orders.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            context.Orders.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Vendors.FindAsync(id);
            entity!.IsDeleted = true;
            context.Vendors.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
