using System.Net.NetworkInformation;

namespace Domain.Enums;

public enum InvoiceStateEnum
{
    NewlyCreated,
    Posted,
    Approved,
    RevertedAfterApprovement,
    PostedAndApproved,
    Paid
}