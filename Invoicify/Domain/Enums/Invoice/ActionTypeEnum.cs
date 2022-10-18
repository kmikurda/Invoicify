namespace Domain.Enums.Invoice;

public enum ActionTypeEnum
{
    Created,
    UndoCreation, // Deleted? 
    Canceled,
    SelfAssignment,
    UndoSelfAssignment,
    AssignmentForAuthorization,
    UndoAssignmentForAuthorization,
    Authorization,
    RevertedAuthorization,
    RejectedAuthorization,
    UndoAuthorizationAction,
    SendToVerification,
    UndoSendToVerification,
    PositiveVerification,
    ConditionalVerification,
    RequestedForCorrection,
    UndoVerificationAction,
    Posted,
    UndoPosted,
    Paid,
    UndoPaid,
    
}