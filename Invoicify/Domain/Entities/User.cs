using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    [MaxLength(32)]
    public string Name { get; set; }
    [MaxLength(256)]
    public string Surname { get; set; }
    public List<UserRole> Roles { get; set; }
    public List<UserContractor>? AssociatedContractors { get; set; }

    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    
}