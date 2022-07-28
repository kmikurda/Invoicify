namespace Domain.Enums.Authorization;

public enum AuthorizationStateEnum
{
    WaitingForApproval,
    Approved,
    ApprovedPartially,
    Reverted,
    Rejected,
}