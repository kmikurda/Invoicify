using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Read;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InvoiceReadRepository : ReadRepository<Invoice>, IInvoiceReadRepository
{
    private readonly InvoicifyContext _context;

    public InvoiceReadRepository(InvoicifyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Invoice>> GetInvoiceHistory(int id)
    {
        var result = await _context.Invoices.TemporalAll().Where(x => x.Id == id).ToListAsync();
        return result;
    }
}