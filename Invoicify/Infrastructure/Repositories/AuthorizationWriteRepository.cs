using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Write;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorizationWriteRepository : WriteRepository<Authorization>, IAuthorizationWriteRepository
{
    private readonly InvoicifyContext _context;

    public AuthorizationWriteRepository(InvoicifyContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Authorization> GetLastAuthorizationByInvoice(int invoiceId)
    {
        return await _context.Authorizations.Where(x => x.InvoiceId == invoiceId).OrderByDescending(x => x.CreateDate)
            .SingleOrDefaultAsync();
    }
}