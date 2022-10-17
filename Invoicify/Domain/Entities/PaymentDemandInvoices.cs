namespace Domain.Entities;

public class PaymentDemandInvoices
{
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int PaymentDemandId { get; set; }
    public PaymentDemand PaymentDemand { get; set; }
}