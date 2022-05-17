using Billet.Server.Models.Invoicing;
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

        public async Task<IEnumerable<Invoice>> ListAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetAsync(Guid id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id) ?? new Invoice();
        }

        public async Task UpdateAsync(Invoice entity)
        {
            if (await _context.Invoices.AnyAsync(x => x.Id == entity.Id))
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
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            if(invoice == null)
            {
                throw new ArgumentException($"Invoice with Id = {id}");
            }
            _context.Invoices.Remove(invoice);
        }
    }
}
