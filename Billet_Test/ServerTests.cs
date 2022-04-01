using Billet.Server.Data;
using Billet.Server.Models;
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
        public async Task GetAllAsync_Returns_Invoice()
        {
            var options = new DbContextOptionsBuilder<InvoiceContext>()
            .UseInMemoryDatabase(databaseName: "InvoiceDatabase")
            .Options;

            using(var context = new InvoiceContext(options))
            {
                context.Invoices.Add(new Invoice());
                await context.SaveChangesAsync();
            }

            using(var context = new InvoiceContext(options))
            {
                InvoiceRepository repository = new InvoiceRepository(context);
                var result = await repository.GetAllAsync();
                Assert.That(result, Is.Not.Null);
                Assert.AreEqual(result.Count(), 3);
            }
        }
    }
}
