using HelpDesk.Domain.Entities;

namespace ASPNETCoreWebAPI_CQRS.Application.Repositories;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<Ticket?> GetByIdAsync(int id);
    Task<IReadOnlyList<Ticket>> GetAllAsync();
}
