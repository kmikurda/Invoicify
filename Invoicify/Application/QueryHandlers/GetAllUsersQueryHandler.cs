using Application.Queries;
using Domain.Entities;
using MediatR;

namespace Application.QueryHandlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<User>>
{
    public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException(); //TODO dodać DbContext lub repository
    }
}