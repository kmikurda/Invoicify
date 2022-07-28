using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class Context : DbContext 
{
    public DbSet<Invoice> Invoices { get; set; }
    
    public Context()
    {
        
    }
}