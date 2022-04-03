using Billet.Server.Models.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billet.Server.Models.Invoicing
{
    public class Payor : IPayor
    {
        public Address? Address { get; set; }

        public List<FinancialTransaction> Transactions { get; set; } = new List<FinancialTransaction>();


        [NotMapped]
        public List<Invoice> Invoices {  get; set;} = new List<Invoice>();
    }
}