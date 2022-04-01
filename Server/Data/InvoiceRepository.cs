using Billet.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Billet.Server.Data
{
    public class InvoiceRepository : IRepository<Invoice>
    {
        private readonly InvoiceContext _context;

        public InvoiceRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetAsync(Guid id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id) ?? new Invoice();
        }

        public async Task SaveAsync(Invoice entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
