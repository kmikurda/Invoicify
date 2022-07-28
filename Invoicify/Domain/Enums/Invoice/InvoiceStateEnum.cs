namespace Domain.Enums.Invoice;

public enum InvoiceStateEnum
{
    WaitingForPosting,
    Posted,
    AcceptedAfterCompatibilityAnalysis,
    Paid,
    WaitingForCorrection,
    AcceptedAfterCorrection,
    TemporarilyBlocked,
    Suspended
}