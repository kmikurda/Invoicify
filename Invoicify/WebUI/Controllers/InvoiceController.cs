using System.Diagnostics;
using Domain.Entities;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;
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
    private readonly IAuthorizationWriteRepository _authorizationWriteRepository;

    public InvoiceController(IInvoiceReadRepository invoiceReadRepository, IInvoiceWriteRepository invoiceWriteRepository, IAuthorizationWriteRepository authorizationWriteRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
        _invoiceWriteRepository = invoiceWriteRepository;
        _authorizationWriteRepository = authorizationWriteRepository;
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
    
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateInvoiceAuthorization(string remark, int invoiceId)
    {
        var date = DateTime.Now;
        var authorization = new Authorization()
        {
            InvoiceId = invoiceId,
            Remark = remark,
            AuthorizationState = AuthorizationStateEnum.WaitingForApproval,
            CreateDate = date,
            ModDate = date,
            CreatedBy = 6,
            UserId = 8,
            Arch = false
        };

        var invoice = await _invoiceWriteRepository.GetSingleAsync(invoiceId);
        invoice.AuthorizationState = InvoiceAuthorizationStateEnum.WaitingForApproval;
        invoice.ModDate = date;
        
        _authorizationWriteRepository.Add(authorization);
        await _authorizationWriteRepository.SaveChangesAsync();
        await _invoiceWriteRepository.SaveChangesAsync();
        return Ok(invoice);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> EditInvoiceAuthorization(string remark, int invoiceId, AuthorizationStateEnum authState, int authId)
    {
        var date = DateTime.Now;
        var oldAuthorization = await _authorizationWriteRepository.GetFiltered(x => x.InvoiceId == invoiceId);
        oldAuthorization.ModDate = date;
        oldAuthorization.Arch = true;

        var newAuthorization = new Authorization()
        {
            InvoiceId = invoiceId,
            Remark = remark,
            AuthorizationState = authState,
            CreateDate = date,
            ModDate = date,
            CreatedBy = 6,
            Arch = false
        };

        var invoice = await _invoiceWriteRepository.GetSingleAsync(invoiceId);
        invoice.AuthorizationState = SetStateEnum(authState, invoice.AuthorizationState);
        invoice.ModDate = date;
        _authorizationWriteRepository.Add(newAuthorization);
        await _authorizationWriteRepository.SaveChangesAsync();
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


    public InvoiceAuthorizationStateEnum SetStateEnum(AuthorizationStateEnum authEnum,
        InvoiceAuthorizationStateEnum currState)
    {
        if (authEnum == AuthorizationStateEnum.Reverted && currState == InvoiceAuthorizationStateEnum.WaitingForApproval)
            return InvoiceAuthorizationStateEnum.Reverted;
        if (authEnum == AuthorizationStateEnum.ApprovedPartially && currState == InvoiceAuthorizationStateEnum.WaitingForApproval)
            return InvoiceAuthorizationStateEnum.ApprovedPartially;
        if (authEnum == AuthorizationStateEnum.Approved && currState == InvoiceAuthorizationStateEnum.WaitingForApproval)
            return InvoiceAuthorizationStateEnum.Approved;
        if (authEnum == AuthorizationStateEnum.Approved && currState == InvoiceAuthorizationStateEnum.WaitingForFullyApproval)
            return InvoiceAuthorizationStateEnum.Approved;

        return InvoiceAuthorizationStateEnum.None;
    }
}