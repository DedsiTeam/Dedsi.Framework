﻿using Dedsi.Ddd.CQRS.Commands;

namespace Dedsi.Ddd.CQRS.CommandHandlers;

public abstract class DedsiCommandHandler<TCommand> : IDedsiCommandHandler<TCommand>
    where TCommand : DedsiCommand
{
    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class DedsiCommandHandler<TCommand, TResponse> : IDedsiCommandHandler<TCommand, TResponse>
    where TCommand : DedsiCommand<TResponse>
{
    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}