using HelpDesk.Domain.Entities;

namespace ASPNETCoreWebAPI_CQRS.Application.Services;

public interface ITicketService
{
    Task<IReadOnlyList<Ticket>> GetTicketsAsync();
    Task<Ticket?> GetTicketAsync(int id);
    Task<Ticket> CreateTicketAsync(string title, string descrption);

    // delete, update, etc...  CRUD = create-read-update-delete
    
    Task<Ticket> AssignTicketAsync(int id, string assignedTo);
    Task<Ticket> CloseTicketAsync(int id);

    Task<Ticket> ReopenTicketAsync(int id);
    Task<Ticket> EscalateTicketAsync(int id);
    Task<Ticket> AddCommentAsync(int id, string comment);
    Task<Ticket> ChangePriorityAsync(int id, int priority);
}
