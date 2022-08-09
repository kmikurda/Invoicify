using Domain.Entities;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Microsoft.AspNetCore.Mvc;

namespace Invoicify.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;
    private readonly IInvoiceWriteRepository _invoiceWriteRepository;

    public InvoiceController(IInvoiceReadRepository invoiceReadRepository, IInvoiceWriteRepository invoiceWriteRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
        _invoiceWriteRepository = invoiceWriteRepository;
    }

    [HttpGet("[action]")]
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
            InternalInvoiceNumber = "asd",
            HasPZ = true,
            HasToBeAuthorized = true,
            ContractorId = 1
        };
        _invoiceWriteRepository.Add(invoice);
        await _invoiceWriteRepository.SaveChangesAsync();
        return Ok(invoice);
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> SeedInvoiceHistory()
    {
        var invoice = new Invoice()
        {
            CreateDate = DateTime.Now,
            ModDate = DateTime.Now,
            DateOfPurchase = DateTime.Now,
            InternalInvoiceNumber = "FV-008-2022",
            HasPZ = true,
            HasToBeAuthorized = true,
            ContractorId = 1
        };
        _invoiceWriteRepository.Add(invoice);
        
        var authorization = new Authorization()
        {
            C
        }
            
            
            
            
        await _invoiceWriteRepository.SaveChangesAsync();
        return Ok(invoice);
    }
    
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RenameInvoice(string newName)
    {
        var invoice = await _invoiceWriteRepository.GetSingleAsync(2);
        invoice.InternalInvoiceNumber = newName;
        await _invoiceWriteRepository.SaveChangesAsync();

        var temp = await _invoiceReadRepository.GetSingleAsync(2);
        return Ok(invoice);

    }

    

    [HttpPost("[action]")]
    public async Task<IActionResult> AddInvoice(Invoice invoice)
    {
        _invoiceWriteRepository.Add(invoice);
        await _invoiceWriteRepository.SaveChangesAsync();
        return Ok(invoice);
    }
}