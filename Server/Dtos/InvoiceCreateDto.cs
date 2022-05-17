using Billet.Server.Models.Invoicing;

namespace Billet.Server.Dtos
{
    public class InvoiceCreateDto
    {
        public IEnumerable<ILineItem>? LineItems { get; set; }
        public IPayor Payor { get; set; }
        public IPayee Payee { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDeposited { get; set; }
    }
}
