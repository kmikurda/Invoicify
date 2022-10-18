namespace Domain.Entities;

public class FactoringAgreementInvoices
{
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int FactoringAgreementId { get; set; }
    public FactoringAgreement FactoringAgreement { get; set; }
}