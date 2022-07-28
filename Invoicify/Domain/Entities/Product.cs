using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string Name { get; set; }
    public int Qty { get; set; }
    public double NetPrice { get; set; }
    public int Vat { get; set; }
}