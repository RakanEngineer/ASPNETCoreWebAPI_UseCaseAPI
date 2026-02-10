namespace ASPNETCoreWebAPI_CQRS.Dtos.Tickets;

public record TicketDto(int Id, string Title, string Description, DateTime CreatedAt, string? AssignedTo, string Comment);