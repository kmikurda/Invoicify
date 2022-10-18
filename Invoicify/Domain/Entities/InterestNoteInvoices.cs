namespace Domain.Entities;

public class InterestNoteInvoices
{
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int InterestNoteId { get; set; }
    public InterestNote InterestNote { get; set; }
}