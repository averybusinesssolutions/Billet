using Billet.Server.Dtos;
using Billet.Server.Models.Invoicing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billet.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly Data.InvoiceRepository _invoiceRepository;

        public InvoiceController(Data.InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<IEnumerable<InvoiceReadDto>> GetAsync()
        {
            var invoices = await _invoiceRepository.ListAsync();
            var invoiceDtos = from invoice in invoices
                              select new InvoiceReadDto()
                              {
                                  Id = invoice.Id,
                                  Payee = invoice.Payee,
                                  Payor = invoice.Payor,
                                  IsApproved = invoice.IsApproved,
                                  IsDeposited = invoice.IsDeposited,
                                  IsPaid = invoice.IsPaid,
                                  LineItems = invoice.LineItems
                              };

            return invoiceDtos;
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<InvoiceReadDto> GetAsync(Guid id)
        {
            var invoice = await _invoiceRepository.GetAsync(id);
            return new InvoiceReadDto()
            {
                Id = invoice.Id,
                Payee = invoice.Payee,
                Payor = invoice.Payor,
                IsApproved = invoice.IsApproved,
                IsDeposited = invoice.IsDeposited,
                IsPaid = invoice.IsPaid,
                LineItems = invoice.LineItems
            };
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InvoiceCreateDto invoiceDto)
        {
            Invoice invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                IsApproved = invoiceDto.IsApproved,
                IsDeposited = invoiceDto.IsDeposited,
                IsPaid = invoiceDto.IsPaid,
                LineItems = invoiceDto.LineItems,
                Payee = invoiceDto.Payee,
                Payor= invoiceDto.Payor,
            };

            await _invoiceRepository.UpdateAsync(invoice);

            await _invoiceRepository.SaveAsync();
            return CreatedAtAction(nameof(GetAsync), invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] InvoiceCreateDto invoiceDto)
        {
            var invoice = await _invoiceRepository.GetAsync(id);
            invoice.IsApproved = invoiceDto.IsApproved;
            invoice.IsDeposited = invoiceDto.IsDeposited;
            invoice.IsPaid = invoiceDto.IsPaid;
            invoice.LineItems = invoiceDto.LineItems;
            invoice.Payee = invoiceDto.Payee;
            invoice.Payor = invoiceDto.Payor;

            await _invoiceRepository.UpdateAsync(invoice);

            await _invoiceRepository.SaveAsync();
            return Ok(invoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var invoice = await _invoiceRepository.GetAsync(id);
            if(invoice == null)
            {
                return NotFound();
            }
            await _invoiceRepository.DeleteAsync(id);
            await _invoiceRepository.SaveAsync();
            return Ok(invoice);
        }
    }
}
