using Domain.Entities;
using Domain.Enums;
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
    public DbSet<InvoiceHistory> InvoiceHistory { get; set; }
    public DbSet<Contractor>? Contractors { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<AccountingNote>? AccountingNotes { get; set; }
    public DbSet<InterestNote>? InterestNotes { get; set; }
    public DbSet<PaymentDemand>? PaymentDemands { get; set; }
    public DbSet<Cession> Cessions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable("Invoices");
        modelBuilder.Entity<InvoiceHistory>().ToTable("InvoiceHistory");
        modelBuilder.Entity<Contractor>().ToTable("Contractors");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<AccountingNote>().ToTable("AccountingNotes");
        modelBuilder.Entity<InterestNote>().ToTable("InterestNotes");
        modelBuilder.Entity<PaymentDemand>().ToTable("PaymentDemands");
        modelBuilder.Entity<Cession>().ToTable("Cessions");
        
        //Invoice
        modelBuilder.Entity<Invoice>().HasOne<Contractor>(i => i.Contractor)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.ContractorId);

        modelBuilder.Entity<Invoice>().HasMany<InvoiceHistory>(i => i.InvoiceHistory)
            .WithOne(a => a.Invoice)
            .HasForeignKey(a => a.InvoiceId);

        modelBuilder.Entity<Invoice>().HasOne<User>(i => i.CurrentOwner)
            .WithMany(co => co.InvoicesOwnership)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(i => i.CurrentOwnerId);
        
        modelBuilder.Entity<Invoice>().HasOne<User>(i => i.UserAssignmentForAuthorization)
            .WithMany(co => co.InvoicesForAuthorization)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(i => i.UserAssignmentForAuthorizationId);
        

        //Payment demand
        modelBuilder.Entity<PaymentDemand>().HasOne<Contractor>(i => i.Contractor)
            .WithMany(c => c.PaymentDemands)
            .HasForeignKey(i => i.ContractorId);
        
        //Interest note
        modelBuilder.Entity<InterestNote>().HasOne<Contractor>(i => i.Contractor)
            .WithMany(c => c.InterestNotes)
            .HasForeignKey(i => i.ContractorId);

        //Accounting note
        modelBuilder.Entity<AccountingNote>().HasOne<Contractor>(i => i.Contractor)
            .WithMany(c => c.AccountingNotes)
            .HasForeignKey(i => i.ContractorId);

        //Cession
        modelBuilder.Entity<Cession>().HasOne<Contractor>(c => c.Contractor)
            .WithMany(c => c.Cessions)
            .HasForeignKey(x => x.ContractorId);



    }
}