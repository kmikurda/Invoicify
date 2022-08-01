namespace Domain.Entities;

public class UserContractor
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int ContractorId { get; set; }
    public Contractor Contractor { get; set; }
}