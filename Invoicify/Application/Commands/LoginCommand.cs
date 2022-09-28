using Common.CQRS.Commands;

namespace Application.Commands;

public class LoginCommand : BaseCommand
{
    public string UserName { get; set; }
    public string Password { get; set; }
}