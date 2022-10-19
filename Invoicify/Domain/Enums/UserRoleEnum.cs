using System.ComponentModel;

namespace Domain.Enums;

public enum UserRoleEnum
{
    [Description("Przeglądający")]
    Readonly = 1,
    [Description("Potwierdzający")]
    Approval,
    [Description("Księgowość")]
    Bookkeeping = 10,
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
    Admin = 100,
    [Description("DevAdmin")]
    DevAdmin,
}