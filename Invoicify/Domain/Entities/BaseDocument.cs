using Domain.Enums;

namespace Domain.Entities;

public class BaseDocument : BaseEntity
{
    public string DocumentNumber { get; set; }
    public Contractor Contractor { get; set; }
    public int ContractorId { get; set; }
    public double GrossAmount { get; set; }
    public CurrencyEnum Currency { get; set; }
    public DateTime PaymentDeadline { get; set; }
    public string? BarCodeNumber { get; set; }
    public string? Remark { get; set; }
}