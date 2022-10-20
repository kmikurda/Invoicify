using Common.CQRS.Queries;
using Domain.Entities;

namespace Application.Queries.Invoices;

public class GetInvoiceByIdQuery: BaseQuery<Invoice>
{
    public int InvoiceId { get; set; }
}