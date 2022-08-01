using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;

namespace Domain.Entities;

public class Invoice : BaseEntity
{
    [MaxLength(64)]
    public string? InvoiceNumber { get; set; }
    [MaxLength(64)]
    public string? InternalInvoiceNumber { get; set; }
    public DateTime InvoiceCreateDate { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public DateTime PaymentDeadline { get; set; }
    public double NetPrice { get; set; }
    public double GrossPrice { get; set; }
    public CurrencyEnum Currency { get; set; }
    public bool HasPZ { get; set; }
    [MaxLength(64)]
    public string? PZNumber { get; set; }
    public bool HasToBeAuthorized { get; set; }
    [MaxLength(256)]
    public string? Description { get; set; }
    public InvoiceTypeEnum InvoiceType { get; set; }
    public InvoiceStateEnum InvoiceState { get; set; }
    public InvoiceAuthorizationStateEnum AuthorizationState { get; set; }
    public int ContractorId { get; set; }
    public Contractor Contractor { get; set; }
    public List<InvoiceStateAction>? InvoiceStateActions { get; set; }
    public List<Authorization>? Authorizations { get; set; }
    public List<Product> Products { get; set; }

}