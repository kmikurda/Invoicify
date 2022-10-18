using Common.CQRS.Commands;
using Domain.Entities;

namespace Application.Commands;

public class CreateUserCommand : BaseCommand
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRole Role { get; set; }
}