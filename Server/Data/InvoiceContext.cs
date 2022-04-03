using Billet.Server.Models.Invoicing;
using Microsoft.EntityFrameworkCore;

namespace Billet.Server.Data
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices {  get; set; }

        public InvoiceContext(DbContextOptions options) : base(options)
        {

        }
    }
}
