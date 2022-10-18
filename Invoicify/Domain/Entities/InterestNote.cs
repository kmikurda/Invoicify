namespace Domain.Entities;

public class InterestNote : BaseDocument
{
    public List<InterestNoteInvoices> InterestNoteInvoices { get; set; }

}