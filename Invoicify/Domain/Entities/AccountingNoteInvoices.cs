namespace Domain.Entities;

public class AccountingNoteInvoices
{
    public int AccountingNoteId { get; set; }
    public AccountingNote AccountingNote { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}