using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Contractor
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string Name { get; set; }
    [MaxLength(128)] 
    public string? Street { get; set; }
    [MaxLength(64)]
    public string? City { get; set; }
    [MaxLength(10)]
    public string? ZipCode { get; set; }
    [MaxLength(32)]
    public string? NIP { get; set; }
    [MaxLength(32)]
    public string? REGON { get; set; }

    public List<UserContractor>? AssociatedEmployees { get; set; }
}