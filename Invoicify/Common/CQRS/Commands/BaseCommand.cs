using Common.Helpers.TimeProvider;

namespace Common.CQRS.Commands;

public class BaseCommand : ICommand
{
    protected BaseCommand()
    {
        CreateDate = SystemTime.Now();
    }

    public DateTime CreateDate { get; }
}
