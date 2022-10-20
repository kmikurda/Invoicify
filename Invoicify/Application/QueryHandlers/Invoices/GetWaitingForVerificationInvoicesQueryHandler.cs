using Application.Queries.Invoices;
using Domain.Entities;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetWaitingForVerificationInvoicesQueryHandler : IRequestHandler<GetWaitingForVerificationInvoicesQuery, List<Invoice>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;

    public GetWaitingForVerificationInvoicesQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async Task<List<Invoice>> Handle(GetWaitingForVerificationInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var result = _invoiceReadRepository.FindBy(x => x.InvoiceState == InvoiceStateEnum.WaitingForVerification)
            .ToList();
        return result;
    }

}