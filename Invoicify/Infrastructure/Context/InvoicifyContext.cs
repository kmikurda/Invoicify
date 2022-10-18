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
    public DbSet<Authorization>? Authorizations { get; set; }
    public DbSet<Contractor>? Contractors { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<InvoiceStateAction>? InvoiceStateActions { get; set; }
    public DbSet<AccountingNote>? AccountingNotes { get; set; }
    public DbSet<AccountingNoteInvoices>? AccountingNoteInvoices { get; set; }
    public DbSet<FactoringAgreement>? FactoringAgreements { get; set; }
    public DbSet<FactoringAgreementInvoices>? FactoringAgreementInvoices { get; set; }
    public DbSet<InterestNote>? InterestNotes { get; set; }
    public DbSet<InterestNoteInvoices>? InterestNoteInvoices { get; set; }
    public DbSet<PaymentDemand>? PaymentDemands { get; set; }
    public DbSet<PaymentDemandInvoices>? PaymentDemandInvoices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable("Invoices");
        modelBuilder.Entity<Authorization>().ToTable("Authorizations");
        modelBuilder.Entity<Contractor>().ToTable("Contractors");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<InvoiceStateAction>().ToTable("InvoiceStateActions");
        modelBuilder.Entity<AccountingNote>().ToTable("AccountingNotes");
        modelBuilder.Entity<AccountingNoteInvoices>().ToTable("AccountingNoteInvoices");
        modelBuilder.Entity<FactoringAgreement>().ToTable("FactoringAgreements");
        modelBuilder.Entity<FactoringAgreementInvoices>().ToTable("FactoringAgreementInvoices");
        modelBuilder.Entity<InterestNote>().ToTable("InterestNotes");
        modelBuilder.Entity<InterestNoteInvoices>().ToTable("InterestNoteInvoices");
        modelBuilder.Entity<PaymentDemand>().ToTable("PaymentDemands");
        modelBuilder.Entity<PaymentDemandInvoices>().ToTable("PaymentDemandInvoices");
        
        modelBuilder.Entity<PaymentDemandInvoices>().HasKey(x => new {x.InvoiceId, x.PaymentDemandId});
        modelBuilder.Entity<InterestNoteInvoices>().HasKey(x => new {x.InvoiceId, x.InterestNoteId});
        modelBuilder.Entity<FactoringAgreementInvoices>().HasKey(x => new {x.InvoiceId, x.FactoringAgreementId});
        modelBuilder.Entity<AccountingNoteInvoices>().HasKey(x => new {x.InvoiceId, x.AccountingNoteId});
        
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