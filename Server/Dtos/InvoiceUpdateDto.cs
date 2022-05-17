using Billet.Server.Models.Invoicing;

namespace Billet.Server.Dtos
{
    public class InvoiceUpdateDto
    {
        public Guid Id { get; set; }
        public IEnumerable<ILineItem>? LineItems { get; set; }
        public int PayorId { get; set; }
        public int Payee { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDeposited { get; set; }
    }
}
