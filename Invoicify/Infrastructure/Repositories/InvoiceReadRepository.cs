using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Read;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class InvoiceReadRepository : ReadRepository<Invoice>, IInvoiceReadRepository
{
    private readonly InvoicifyContext _context;

    public InvoiceReadRepository(InvoicifyContext context) : base(context)
    {
        _context = context;
    }
}