using ASPNETCoreWebAPI_CQRS.Application.Repositories;
using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI_CQRS.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _dbContext;

    public TicketRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _dbContext.Tickets.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Ticket>> GetAllAsync()
    {
        return await _dbContext.Tickets.AsNoTracking().ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _dbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task UpdateAsync(Ticket ticket)
    {
        _dbContext.Tickets.Update(ticket);
        await _dbContext.SaveChangesAsync();
    }

}
