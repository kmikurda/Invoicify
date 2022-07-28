using System.ComponentModel;

namespace Domain.Enums;

public enum UserRoleEnum
{
    [Description("Przeglądający")]
    Readonly,
    [Description("Potwierdzający")]
    Approval,
    [Description("Księgowość")]
    Bookkeeping,
    [Description("Kierownik księgowości")]
    BookkeepingSupervisor,
    [Description("Kancelaria")]
    Chambers,
    [Description("Kierownik kancelarii")]
    ChambersSupervisor,
    [Description("Dział zakupów")]
    PurchasingDepartment,
    [Description("Kierownik działu zakupów")]
    PurchasingDepartmentSupervisor,
    [Description("Administrator")]
    Admin,
    [Description("DevAdmin")]
    DevAdmin,
}