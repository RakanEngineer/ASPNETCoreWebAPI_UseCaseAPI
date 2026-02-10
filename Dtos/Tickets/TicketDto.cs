using ASPNETCoreWebAPI_UseCaseAPI.Dtos.Tickets;

namespace ASPNETCoreWebAPI_CQRS.Dtos.Tickets;

public record TicketDto(int Id, string Title, string Description, DateTime CreatedAt, string? AssignedTo, List<CommentDto> Comments, int Priority);