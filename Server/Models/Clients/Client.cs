using Billet.Server.Models.Invoicing;

namespace Billet.Server.Models.Clients
{
    public class Client : IPayor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Address? BillingAddress { get; set; }
        public Address? ShippingAddress { get; set; }
    }
}
