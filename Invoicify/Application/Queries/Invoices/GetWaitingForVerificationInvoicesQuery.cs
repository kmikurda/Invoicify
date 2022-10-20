using Common.CQRS.Queries;
using Domain.Entities;

namespace Application.Queries.Invoices;

public class GetWaitingForVerificationInvoicesQuery : BaseQuery<List<Invoice>>
{
    
}