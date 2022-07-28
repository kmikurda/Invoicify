using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<UserRole> Roles { get; set; }
    public List<UserContractor> AssociatedContractors { get; set; }

    public string login { get; set; }
    public string password { get; set; }
    
}