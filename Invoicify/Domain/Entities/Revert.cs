using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Revert : BaseEntity
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string Reason { get; set; }
    
}