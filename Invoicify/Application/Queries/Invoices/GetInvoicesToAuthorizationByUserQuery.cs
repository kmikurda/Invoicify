using Common.CQRS.Queries;
using Domain.Entities;

namespace Application.Queries.Invoices;

public class GetInvoicesToAuthorizationByUserQuery: BaseQuery<List<Invoice>>
{
    public int UserAssignedForAuthorization { get; set; }   
}