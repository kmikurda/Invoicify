using System.ComponentModel;

namespace Domain.Enums;

public enum UserRole
{
    [Description("Księgowość")]
    Bookkeeping,
    [Description("Kierownik księgowości")]
    BookkeepingSupervisor,
    [Description("Kancelaria")]
    Chambers,
    [Description("Kierownik kancelarii")]
    ChambersSupervisor,
    [Description("Administrator")]
    Admin,
    [Description("Przeglądający")]
    Readonly,
    
}