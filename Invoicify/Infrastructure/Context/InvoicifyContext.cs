using System.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class InvoicifyContext : DbContext
{
    private readonly string _connectionString;

    public InvoicifyContext()
    {
        
    }

    public InvoicifyContext(DbContextOptions<InvoicifyContext> options) : base(options)
    {
        
    }

    public InvoicifyContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Authorization> Authorizations { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserContractor> UserContractor { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Revert> Reverts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable("Invoices");
        modelBuilder.Entity<Authorization>().ToTable("Invoices");
        modelBuilder.Entity<Contractor>().ToTable("Invoices");
        modelBuilder.Entity<Product>().ToTable("Invoices");
        modelBuilder.Entity<User>().ToTable("Invoices");
        modelBuilder.Entity<UserContractor>().ToTable("Invoices");
        modelBuilder.Entity<UserRole>().ToTable("Invoices");
        modelBuilder.Entity<Revert>().ToTable("Invoices");


        modelBuilder.Entity<UserContractor>().HasKey(x => new {x.UserId, x.ContractorId});
        
    }
}