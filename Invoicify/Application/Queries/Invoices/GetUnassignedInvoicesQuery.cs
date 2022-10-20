using Common.CQRS.Queries;
using Domain.Entities;

namespace Application.Queries.Invoices;

public class GetUnassignedInvoicesQuery : BaseQuery<List<Invoice>>
{
    
}