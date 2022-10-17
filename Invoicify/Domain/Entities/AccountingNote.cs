namespace Domain.Entities;

public class AccountingNote : BaseDocument
{
    public string ChargeReason { get; set; }
    public List<AccountingNoteInvoices> AccountingNoteInvoicesList { get; set; }

}