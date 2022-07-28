using Application.Commands;
using Domain.Entities;
using MediatR;

namespace Application.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException(); //TODO 
    }
}