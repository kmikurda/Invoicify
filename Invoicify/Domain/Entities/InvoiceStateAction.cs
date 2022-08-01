using System.ComponentModel.DataAnnotations;
using Domain.Enums.Invoice;

namespace Domain.Entities;

public class InvoiceStateAction : BaseEntity
{
    [MaxLength(256)]
    public string? Remark { get; set; }
    public InvoiceStateEnum InvoiceState { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}