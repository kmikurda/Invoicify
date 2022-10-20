using System.Diagnostics;
using Application.Queries.Invoices;
using Common.CQRS.Commands;
using Common.CQRS.Queries;
using Domain.Entities;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoicify.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IQueryBus _queryBus;
    private readonly ICommandBus _commandBus;

    public InvoiceController(IQueryBus queryBus, ICommandBus commandBus)
    {
        _queryBus = queryBus;
        _commandBus = commandBus;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]

    public async Task<IActionResult> GetAllInvoices()
    {
        var result = await _queryBus.Send<GetAllInvoicesQuery, List<Invoice>>(new GetAllInvoicesQuery());
        return result.IsNullOrEmpty() == false ?  Ok(result) :  NotFound();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var result = await _queryBus.Send<GetInvoiceByIdQuery, Invoice>(new GetInvoiceByIdQuery());
        return result == null ?  Ok(result) :  NotFound();
    }

    
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]
    public async Task<IActionResult> GetUnassignedInvoices()
    {
        var result = await _queryBus.Send<GetUnassignedInvoicesQuery, List<Invoice>>(new GetUnassignedInvoicesQuery());
        return result.IsNullOrEmpty() == false ?  Ok(result) :  NotFound();
    }

    [HttpGet("[action]/{id:int}")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]
    public async Task<IActionResult> GetInvoicesByOwner(int id)
    {
        var result = await _queryBus.Send<GetInvoiceByOwnerQuery, List<Invoice>>
        (new GetInvoiceByOwnerQuery(){OwnerId = id});
        return result.IsNullOrEmpty() == false ?  Ok(result) :  NotFound();
    }
    
    [HttpGet("[action]/{id:int}")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]
    public async Task<IActionResult> GetInvoicesToAuthorizationByUser(int id)
    {
        var result = await _queryBus.Send<GetInvoicesToAuthorizationByUserQuery, List<Invoice>>
            (new GetInvoicesToAuthorizationByUserQuery(){UserAssignedForAuthorization = id});
        return result.IsNullOrEmpty() == false ?  Ok(result) :  NotFound();
    }

    [HttpGet("[action]/{id:int}")]
    [ProducesResponseType(typeof(List<Invoice>), 200)]
    public async Task<IActionResult> GetWaitingForVerificationInvoices()
    {
        var result = await _queryBus.Send<GetWaitingForVerificationInvoicesQuery, List<Invoice>>(new GetWaitingForVerificationInvoicesQuery());
        return result.IsNullOrEmpty() == false ?  Ok(result) :  NotFound();
    }
    
    

}