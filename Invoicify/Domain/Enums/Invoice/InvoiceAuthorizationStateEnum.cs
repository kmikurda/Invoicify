namespace Domain.Enums.Invoice;

public enum InvoiceAuthorizationStateEnum
{
    None,
    WaitingForApproval,
    Approved,
    ApprovedPartially,
    Reverted,
    Rejected,
    WaitingForFullyApproval,
    WaitingForSupervisorDecision,
    WaitingForAbsoluteApproval
}