namespace Domain.Entities;

public class PaymentDemand : BaseDocument
{
    public List<PaymentDemandInvoices> PaymentDemandInvoicesList { get; set;}
}