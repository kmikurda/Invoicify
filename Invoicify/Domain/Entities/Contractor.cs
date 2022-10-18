using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Contractor : BaseEntity
{
    [MaxLength(256)]
    public string Name { get; set; }
    [MaxLength(128)] 
    public string? Street { get; set; }
    [MaxLength(64)]
    public string? City { get; set; }
    [MaxLength(10)]
    public string? ZipCode { get; set; }
    [MaxLength(32)]
    public string? NIP { get; set; }
    [MaxLength(32)]
    public string? REGON { get; set; }
    public List<Invoice>? Invoices { get; set; }
    public List<PaymentDemand>? PaymentDemands { get; set; }
    public List<AccountingNote> AccountingNotes { get; set; }
    public List<InterestNote> InterestNotes { get; set; }
    public List<Cession> Cessions { get; set; }

}