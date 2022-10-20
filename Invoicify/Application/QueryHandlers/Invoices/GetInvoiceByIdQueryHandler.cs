using Application.Queries.Invoices;
using Domain.Entities;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Invoice>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async Task<Invoice> Handle(GetInvoiceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = _invoiceReadRepository.FindBy(x => x.Id == request.InvoiceId).FirstOrDefault();
        return result;
    }

}