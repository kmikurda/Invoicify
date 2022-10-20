using Application.Queries.Invoices;
using Domain.Entities;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetInvoiceByOwnerQueryHandler: IRequestHandler<GetInvoiceByOwnerQuery,List<Invoice>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;


    public GetInvoiceByOwnerQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }
    
    public async Task<List<Invoice>> Handle(GetInvoiceByOwnerQuery request, CancellationToken cancellationToken)
    {
        var invoicesList = _invoiceReadRepository.FindBy(x => x.CurrentOwnerId == request.OwnerId).ToList();
        return invoicesList;
    }
}