using System.ComponentModel;

namespace Domain.Entities;

public class BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    [DefaultValue(false)]
    public bool Arch { get; set; }
}