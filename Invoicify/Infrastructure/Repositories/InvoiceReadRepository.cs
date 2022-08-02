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
        if (_context.Invoices != null)
        {
            var query = await _context.Invoices.TemporalAll()
                .ToListAsync();

            var query2 = await _context.Invoices.TemporalAll()
                .Where(x => x.Id == id).ToListAsync();

            var authorization = await _context.Authorizations.Where(x => x.InvoiceId == id).ToListAsync();
            var invoice
            var query3 = await _context.Invoices.TemporalAll()
                .Include(x => x.Authorizations)
                .Where(x => x.Id == id)
                .ToListAsync();

            return query;
        }
        return null;
    }
}