using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands;

public class CreateUserCommand : IRequest<User>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRole Role { get; set; }
}