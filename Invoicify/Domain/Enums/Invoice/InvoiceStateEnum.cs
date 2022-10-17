namespace Domain.Enums.Invoice;

public enum InvoiceStateEnum
{
    WaitingForPosting,
    Posted,
    Paid,
    TemporarilyBlocked,
    Suspended
}