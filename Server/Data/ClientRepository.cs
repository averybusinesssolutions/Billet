using Microsoft.EntityFrameworkCore;

namespace Billet.Server.Data
{
    public class ClientRepository : IRepository<Models.Clients.Client>
    {
        private readonly ClientContext _context;
        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Clients.Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Models.Clients.Client> GetAsync(Guid id)
        {
            return await _context.Clients.FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Models.Clients.Client entity)
        {
            if (await _context.Clients.AnyAsync(x => x.Id == entity.Id))
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
            {
                throw new ArgumentException($"Invoice with Id = {id}");
            }
            _context.Clients.Remove(client);
        }
    }
}
