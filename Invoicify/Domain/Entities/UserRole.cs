using Domain.Enums;

namespace Domain.Entities;

public class UserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public UserRoleEnum Role { get; set; }
}