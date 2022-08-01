using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.Enums.Authorization;

namespace Domain.Entities;

public class Authorization : BaseEntity
{
    public int Id { get; set; }
    public AuthorizationStateEnum AuthorizationState { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public RejectAuthorizationReasonEnum RejectReason { get; set; }
    public RevertAuthorizationReasonEnum RevertReason { get; set; }
    [MaxLength(256)]
    public string Remark { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}