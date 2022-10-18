namespace Domain.Entities;

public class Cession : BaseEntity
{
    public string DocumentNumber { get; set; }
    public Contractor Contractor { get; set; }
    public int ContractorId { get; set; }
    public string? Remark { get; set; }
}