using System.ComponentModel.DataAnnotations.Schema;

namespace Billet.Server.Models
{
    internal class Payor : IPayor
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public List<FinancialTransaction> Transactions { get; set; }


        [NotMapped]
        public List<Invoice> Invoices {  get; set;}
    }
}