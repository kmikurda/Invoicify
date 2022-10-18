namespace Domain.Entities;

public class FactoringAgreement
{
    public List<FactoringAgreementInvoices> FactoringAgreementInvoices { get; set; }
    public Contractor Factor { get; set; }
}