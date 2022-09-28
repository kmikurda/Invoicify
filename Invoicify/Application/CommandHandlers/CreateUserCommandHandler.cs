using Application.Commands;
using Common.CQRS.Commands;
using Domain.Entities;
using MediatR;

namespace Application.CommandHandlers;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException(); //TODO 
    }
}