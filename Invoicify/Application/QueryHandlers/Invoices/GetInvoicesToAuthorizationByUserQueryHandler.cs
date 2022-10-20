using Application.Queries.Invoices;
using Domain.Entities;
using Domain.Enums.Invoice;
using Infrastructure.Interfaces.Read;
using MediatR;

namespace Application.QueryHandlers.Invoices;

public class GetInvoicesToAuthorizationByUserQueryHandler: IRequestHandler<GetInvoicesToAuthorizationByUserQuery,List<Invoice>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;


    public GetInvoicesToAuthorizationByUserQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }
    
    public async Task<List<Invoice>> Handle(GetInvoicesToAuthorizationByUserQuery request, CancellationToken cancellationToken)
    {
        var invoicesList = _invoiceReadRepository
            .FindBy(x => x.UserAssignmentForAuthorizationId == request.UserAssignedForAuthorization && 
                         (x.AuthorizationState == InvoiceAuthorizationStateEnum.WaitingForApproval ||
                          x.AuthorizationState == InvoiceAuthorizationStateEnum.WaitingForAbsoluteApproval ||
                          x.AuthorizationState == InvoiceAuthorizationStateEnum.WaitingForFullyApproval))
            .ToList();
        return invoicesList;
    }
}