namespace Domain.Enums.Invoice;

public enum InvoiceAuthorizationStateEnum
{
    WaitingForApproval,
    Approved,
    ApprovedPartially,
    Reverted,
    Rejected,
    WaitingForFullyApproval,
    WaitingForSupervisorDecision,
    WaitingForAbsoluteApproval
}