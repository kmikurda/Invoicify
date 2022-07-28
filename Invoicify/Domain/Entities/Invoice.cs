using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Invoice : BaseEntity
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; }
    public string InternalInvoiceNumber { get; set; }
    public DateTime InvoiceCreateDate { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public DateTime PaymentDeadline { get; set; }
    public double NetPrice { get; set; }
    public double GrossPrice { get; set; }
    public CurrencyEnum Currency { get; set; }
    public bool HasPZ { get; set; }
    public bool HasToBeAuthorized { get; set; }
    public string? Description { get; set; }
    public InvoiceTypeEnum InvoiceType { get; set; }
    public InvoiceStateEnum InvoiceState { get; set; }
    public int ContractorId { get; set; }
    public Contractor Contractor { get; set; }
    
    public List<Authorization> Authorizations { get; set; }
    public List<Product> Products { get; set; }

}