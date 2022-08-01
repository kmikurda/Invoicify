using System.ComponentModel;
namespace Domain.Entities;

public class BaseEntity
{
    public DateTime CreateDate { get; set; }
    public DateTime ModDate { get; set; }
    public int CreatedBy { get; set; }
    [DefaultValue(false)]
    public bool Arch { get; set; }
    
    protected BaseEntity()
    {
    }
}