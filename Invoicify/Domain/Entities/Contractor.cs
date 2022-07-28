namespace Domain.Entities;

public class Contractor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? NIP { get; set; }
    public string? REGON { get; set; }

    public List<UserContractor>? AssociatedEmployees { get; set; }
}