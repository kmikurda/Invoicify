namespace Domain.Enums.Invoice;

public enum InvoiceStateEnum
{
    WaitingForPosting,
    Posted,
    WaitingForVerification,
    WaitingForPayment,
    Paid,
    TemporarilyBlocked,
    Suspended
}