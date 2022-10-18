using Application.Interfaces.Read;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories.Base;
using MediatR;

namespace Infrastructure.Repositories;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    private readonly InvoicifyContext _context;

    public UserReadRepository(InvoicifyContext context) : base(context)
    {
        _context = context;
    }
}