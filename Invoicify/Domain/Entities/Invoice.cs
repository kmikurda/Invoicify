using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Enums.Authorization;
using Domain.Enums.Invoice;

namespace Domain.Entities;

public class Invoice : BaseDocument
{
    public string? SAPInvoiceNumber { get; set; }
    public DateTime InvoiceCreateDate { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public bool HasPZ { get; set; }
    public string? PZNumber { get; set; }
    public bool HasToBeAuthorized { get; set; }
    public InvoiceStateEnum InvoiceState { get; set; }
    public InvoiceAuthorizationStateEnum AuthorizationState { get; set; }    
    public PaymentMethod PaymentMethod { get; set; }
    public List<InvoiceHistory>? InvoiceHistory { get; set; }
    public string? InvoiceFilePath { get; set; }
    
    public User? CurrentOwner { get; set; }
    public User? UserAssignmentForAuthorization { get; set; } //TODO Assignment -> Assigned
    public int? CurrentOwnerId { get; set; }
    public int? UserAssignmentForAuthorizationId { get; set; }
    

}