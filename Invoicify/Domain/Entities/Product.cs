using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product : BaseEntity
{
    [MaxLength(256)]
    public string Name { get; set; }
    public int Qty { get; set; }
    public double NetPrice { get; set; }
    public int Vat { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}