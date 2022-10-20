using Common.CQRS.Queries;
using Domain.Entities;

namespace Application.Queries.Invoices;

public class GetInvoiceByOwnerQuery  : BaseQuery<List<Invoice>>
{
    public int OwnerId { get; set; }   
}