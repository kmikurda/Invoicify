using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetAllUsersQuery : IRequest<List<User>>
{
    
}