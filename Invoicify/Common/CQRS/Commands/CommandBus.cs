﻿using MediatR;

namespace Common.CQRS.Commands;

public class CommandBus : ICommandBus
{
    private readonly IMediator _mediator;

    public CommandBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Send<TCommand>(TCommand command) where TCommand : ICommand
    {
        return _mediator.Send(command);
    }
}