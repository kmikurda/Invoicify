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
            // var query = await _context.Invoices.TemporalAll()
            //     .ToListAsync();
            //
            // var query2 = await _context.Invoices.TemporalAll()
            //     .Where(x => x.Id == id).ToListAsync();
            //
            // var authorization = await _context.Authorizations.Where(x => x.InvoiceId == id).ToListAsync();
             var invoice = await _context.Invoices.TemporalAsOf(DateTime.Now).Where(x => x.Id == 2).Select(x => new
            {
                x.Id,
                InvoiceState = x.InvoiceState.ToString(),
                AuthorizationState = x.AuthorizationState.ToString(),
                Authorizations = x.Authorizations.Select(y => y.AuthorizationState).ToList(),
                Actions = x.InvoiceStateActions.Select(y => y.InvoiceState).ToList()
            }).ToListAsync();
            var query3 = await _context.Invoices.TemporalAll()
                .Include(x => x.Authorizations)
                .Where(x => x.Id == id)
                .ToListAsync();

            return new List<Invoice>();
        }
        return null;
    }
}