namespace Billet.Server.Models
{
    public class Invoice
    {
        public Guid Id {  get; set; }
        public IEnumerable<ILineItem>? LineItems { get; set; }
        public IPayor Payor { get; set; }
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
