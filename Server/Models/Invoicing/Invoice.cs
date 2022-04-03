using System.ComponentModel.DataAnnotations.Schema;

namespace Billet.Server.Models.Invoicing
{
    public class Invoice
    {
        public Guid Id {  get; set; }
        [NotMapped]
        public IEnumerable<ILineItem>? LineItems { get; set; }
        [NotMapped]
        public IPayor Payor { get; set; }
        [NotMapped]
        public IPayee Payee { get; set; }
        public bool? IsApproved {  get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDeposited { get; set; }

        public Invoice()
        {
            LineItems = new List<ILineItem>();
            Payor = new Payor();
            Payee = new Payee();
            IsApproved = false;
            IsPaid = false;
            IsDeposited = false;
        }
    }
}
