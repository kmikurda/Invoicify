namespace Application.Vm;

public class InvoiceHistoryEntry
{
    public string Remark { get; set; }
    public DateTime CreateDate { get; set; }
    public string PreviousState  { get; set; }
    public string CurrentState { get; set; }
    public string CreateBy { get; set; }
}