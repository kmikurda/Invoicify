using Domain.Entities;

namespace Infrastructure.Interfaces.Read;

public interface IInvoiceReadRepository : IReadRepository<Invoice>
{
    Task<List<Invoice>> GetInvoiceHistory(int id);
}