using Common.CQRS.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Invoices;

public class GetAllInvoicesQuery : BaseQuery<List<Invoice>>
{
    
}