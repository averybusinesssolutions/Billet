using Billet.Server.Data;
using Billet.Server.Models.Invoicing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billet_Test
{
    public class ServerTests
    {
        [Test]
        public async Task ListAsync_Returns_ListOfInvoices()
        {
            var options = new DbContextOptionsBuilder<InvoiceContext>()
            .UseInMemoryDatabase(databaseName: "InvoiceDatabase")
            .Options;

            using(var context = new InvoiceContext(options))
            {
                context.Invoices.Add(new Invoice() { Id = Guid.NewGuid() });
                await context.SaveChangesAsync();
            }

            using(var context = new InvoiceContext(options))
            {
                InvoiceRepository repository = new InvoiceRepository(context);
                var result = await repository.ListAsync();
                Assert.That(result, Is.Not.Null);
                Assert.AreEqual(result.Count(), 1);
            }
        }

        [Test]
        public async Task SaveAsync_InvoicesCountEquals1()
        {
            var options = new DbContextOptionsBuilder<InvoiceContext>()
            .UseInMemoryDatabase(databaseName: "InvoiceDatabase")
            .Options;

            var context = new InvoiceContext(options);

            var repo = new InvoiceRepository(context);
            var invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                IsApproved = false,
                IsDeposited = false,
                IsPaid = false,
                Payee = new Payee(),
                Payor = new Payor()
            };
            await repo.UpdateAsync(invoice);
            await repo.SaveAsync();
            Assert.AreEqual(1, context.Invoices.Count());
        }

        [Test]
        public async Task GetAsync_Returns_Invoice()
        {
            var options = new DbContextOptionsBuilder<InvoiceContext>()
            .UseInMemoryDatabase(databaseName: "InvoiceDatabase")
            .Options;

            var context = new InvoiceContext(options);

            var repo = new InvoiceRepository(context);
            var id = Guid.NewGuid();
            var invoice = new Invoice()
            {
                Id = id,
                IsApproved = false,
                IsDeposited = false,
                IsPaid = false,
                Payee = new Payee(),
                Payor = new Payor()
            };
            await repo.UpdateAsync(invoice);
            await repo.SaveAsync();

            var result = await repo.GetAsync(id);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == id);
        }
   
    }
}
