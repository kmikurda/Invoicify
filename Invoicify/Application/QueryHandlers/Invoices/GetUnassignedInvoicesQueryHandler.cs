using Application.Queries.Invoices;
using Domain.Entities;
using Infrastructure.Interfaces.Read;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetUnassignedInvoicesQueryHandler : IRequestHandler<GetUnassignedInvoicesQuery, List<Invoice>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;


    public GetUnassignedInvoicesQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async Task<List<Invoice>> Handle(GetUnassignedInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoicesList =  _invoiceReadRepository.FindBy(x => x.CurrentOwner == null).ToList();
        return invoicesList;
    }
}