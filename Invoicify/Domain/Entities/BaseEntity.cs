using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModDate { get; set; }
    public int CreatedBy { get; set; }
    [DefaultValue(false)]
    public bool Arch { get; set; }
    
    protected BaseEntity()
    {
    }
}