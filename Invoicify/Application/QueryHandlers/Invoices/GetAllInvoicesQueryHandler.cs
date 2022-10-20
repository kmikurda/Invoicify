using Application.Queries.Invoices;
using Domain.Entities;
using Infrastructure.Interfaces.Read;
using Infrastructure.Interfaces.Write;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery,List<Invoice>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;


    public GetAllInvoicesQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }
    
    public async Task<List<Invoice>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoicesList = await _invoiceReadRepository.GetAllAsync();
        return invoicesList;
    }
}