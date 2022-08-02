using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class InvoicifyContext : DbContext
{
    private readonly string? _connectionString;
    public static string ConnectionStringName = "InvoicifyContext";


    public InvoicifyContext()
    {
        
    }

    public InvoicifyContext(DbContextOptions<InvoicifyContext> options) : base(options)
    {
        
    }

    public InvoicifyContext(string? connectionString)
    {
        _connectionString = connectionString;
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    public DbSet<Invoice>? Invoices { get; set; }
    public DbSet<Authorization>? Authorizations { get; set; }
    public DbSet<Contractor>? Contractors { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<UserContractor>? UserContractor { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<InvoiceStateAction>? InvoiceStateActions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable("Invoices", i => i.IsTemporal());
        modelBuilder.Entity<Authorization>().ToTable("Authorizations", a => a.IsTemporal());
        modelBuilder.Entity<Contractor>().ToTable("Contractors");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<UserContractor>().ToTable("UserContractor");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<InvoiceStateAction>().ToTable("InvoiceStateActions", ia => ia.IsTemporal());


        modelBuilder.Entity<UserContractor>().HasKey(x => new {x.UserId, x.ContractorId});
        
        modelBuilder.Entity<Invoice>().HasOne<Contractor>(i => i.Contractor)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.ContractorId);

        modelBuilder.Entity<Invoice>().HasMany<Authorization>(i => i.Authorizations)
            .WithOne(a => a.Invoice)
            .HasForeignKey(a => a.InvoiceId);

        modelBuilder.Entity<Invoice>().HasMany<Product>(i => i.Products)
            .WithOne(p => p.Invoice)
            .HasForeignKey(p => p.InvoiceId);

        modelBuilder.Entity<Invoice>().HasMany<InvoiceStateAction>(i => i.InvoiceStateActions)
            .WithOne(ia => ia.Invoice)
            .HasForeignKey(ia => ia.InvoiceId);

    }
}