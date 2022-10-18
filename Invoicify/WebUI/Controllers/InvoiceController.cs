using System.Diagnostics;
using Domain.Entities;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoicify.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;
    private readonly IInvoiceWriteRepository _invoiceWriteRepository;

    public InvoiceController(IInvoiceReadRepository invoiceReadRepository,
        IInvoiceWriteRepository invoiceWriteRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
        _invoiceWriteRepository = invoiceWriteRepository;
    }

    [HttpGet("[action]")]
    [Authorize]
    public async Task<IActionResult> GetAllInvoices()
    {
        var result = await _invoiceReadRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetInvoiceHistory()
    {
        var result = await _invoiceReadRepository.GetInvoiceHistory(2);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> SeedInvoice()
    {
        var invoice = new Invoice()
        {
            CreateDate = DateTime.Now,
            ModDate = DateTime.Now,
            DateOfPurchase = DateTime.Now,
            HasPZ = true,
            HasToBeAuthorized = true,
            ContractorId = 1
        };
        _invoiceWriteRepository.Add(invoice);
        await _invoiceWriteRepository.SaveChangesAsync();
        return Ok(invoice);
    }
}