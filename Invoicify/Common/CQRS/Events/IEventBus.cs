namespace Common.CQRS.Events;

public interface IEventBus
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}