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

        public async Task SaveAsync(Models.Clients.Client entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
