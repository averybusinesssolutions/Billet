using Microsoft.EntityFrameworkCore;

namespace Billet.Server.Data
{
    public class ClientContext : DbContext
    {
        public DbSet<Server.Models.Clients.Client> Clients { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
    }
}
