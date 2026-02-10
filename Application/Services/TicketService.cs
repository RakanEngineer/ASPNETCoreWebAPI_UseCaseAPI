using ASPNETCoreWebAPI_CQRS.Application.Repositories;
using HelpDesk.Domain.Entities;

namespace ASPNETCoreWebAPI_CQRS.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> CreateTicketAsync(string title, string descrption)
    {
        var ticket = new Ticket
        {
            Title = title,
            Description = descrption
        };

        await _ticketRepository.AddAsync(ticket);

        return ticket;
    }

    public async Task<Ticket?> GetTicketAsync(int id)
        => await _ticketRepository.GetByIdAsync(id);

    public async Task<IReadOnlyList<Ticket>> GetTicketsAsync()
        => await _ticketRepository.GetAllAsync();    
}
