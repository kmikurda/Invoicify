using Common.Helpers.TimeProvider;
using Domain.Enums.Invoice;

namespace Domain.Entities;

public class InvoiceHistory : BaseEntity
{
    public int InvoiceId { get; set; }   
    public Invoice Invoice { get; set; }

    public string? Remark { get; set; }
    public ActionTypeEnum ActionType { get; set; }
}