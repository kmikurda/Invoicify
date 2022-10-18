using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Write;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InvoiceWriteRepository : WriteRepository<Invoice>, IInvoiceWriteRepository
{
    private readonly InvoicifyContext _context;

    public InvoiceWriteRepository(InvoicifyContext context) : base(context)
    {
        _context = context;
    }
}