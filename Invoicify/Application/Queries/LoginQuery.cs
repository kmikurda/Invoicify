using Application.Dto;
using Common.CQRS.Commands;
using Common.CQRS.Queries;

namespace Application.Commands;

public class LoginQuery : BaseQuery<AuthToken>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}