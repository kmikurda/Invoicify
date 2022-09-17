using MediatR;

namespace Common.CQRS.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
