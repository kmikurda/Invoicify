using Common.Helpers.TimeProvider;

namespace Common.CQRS.Queries;

public class BaseQuery<TResponse> : IQuery<TResponse>
{
    protected BaseQuery()
    {
        CreateDate = SystemTime.Now();
    }

    public DateTime CreateDate { get; set; }
}
