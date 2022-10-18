using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;

namespace Domain.Entities;

public class Invoice : BaseDocument
{
    [MaxLength(64)]
    public string? SAPInvoiceNumber { get; set; }
    public DateTime InvoiceCreateDate { get; set; }
    public DateTime DateOfPurchase { get; set; }
    
    public bool HasPZ { get; set; }
    [MaxLength(64)]
    public string? PZNumber { get; set; }
    public bool HasToBeAuthorized { get; set; }
    
    public InvoiceStateEnum InvoiceState { get; set; }
    public InvoiceAuthorizationStateEnum AuthorizationState { get; set; }
    public int ContractorId { get; set; }
    
    //TODO albo to
    public List<InvoiceStateAction>? InvoiceStateActions { get; set; }
    public List<Authorization>? Authorizations { get; set; }
    // TODO albo to
    public List<InvoiceHistory>? InvoiceHistory { get; set; }
    public List<Product>? Products { get; set; }
    public User CurrentOwner { get; set; }

    
    public List<InterestNoteInvoices>? InterestNoteInvoices { get; set; }
    public List<AccountingNoteInvoices>? AccountingNoteInvoices { get; set; }
    public List<PaymentDemandInvoices>? PaymentDemandInvoices { get; set;}
    public List<FactoringAgreementInvoices>? FactoringAgreementInvoices { get; set; }

}