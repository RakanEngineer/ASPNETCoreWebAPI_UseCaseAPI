using ASPNETCoreWebAPI_CQRS.Application.Services;
using ASPNETCoreWebAPI_CQRS.Dtos.Tickets;
using ASPNETCoreWebAPI_UseCaseAPI.Dtos.Tickets;
using HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    // resurs-baserat API / CRUD = Create Read Update Delete
    // REST (4 nivåer - 3)
    //   HTTP metoder (GET, POST, PUT, PATCH DELET)
    //   Resurser som identiieras med URI /tickets, /tickets/1
    // Fokus: entiteter (tabeller i databas)

    // use-case API / use-case-baserade API
    // fokus ej på resruser, fokus istället på use cases

    // # Resursbaserat API - fokus ligger på resurser / entiteter
    // GET /api/tickets
    // GET /api/tickets/1
    // POST /api/tickets
    // PATCH /api/tickets/1
    // DELETE /api/tickets/1

    //POST /api/bank-accounts/{id}/withdraw

    // WithdrawCommand -.> handle -> result

    //POST /api/bank-accounts/{id}/deposit

    // DepositCommand -.> handle -> result



    //GET /api/tickets?status=open  // resursaserads + use cases
    //GET /api/open-tickets   // use case

    // despoit / withdraw

    // POST /api/bank-accounts/create
    // POST /api/bank-accounts/{id}/c
    // -> transaction deposito
    // POST /api/bank-accounts/{id}/withdraw
    // -> transaction withdraw

    // { type: despoit / withdray, amount: 1000, reason: ""


    // # Skapa ärende
    // POST /api/tickets             resurs-basert API
    // POST /api/tickets/create      use-case baserat API

    /*
     
    */

    // REST API:er (resursbaserade - fokus på resurser och att använda 
    // HTTP-metoder för att beskriva avsikt
    // PATCH /api/tickets/1
    // PATCH /api/tickets/1

    // Use-case API / Use-case-baserade API (Task API)
    // Fokus på use case - alltså vad man vill göra
    // POST /api/tickets/1/close
    //     204 No Content
    //     200 OK (+ info)
    //     409 Conflict / 400 Bad Request
    // POST /api/tickets/1/assign        204 No Content

    // # Tilldela ärende ((tilldela ärende "Tilldela ärenden")

    // PATCH /api/tickets/{id}  (DTO Patch / JSON Patch)  (resursbaserat sätt)
    // { "assignedTo": "Nils Nilsson" }

    // PATCH /api/tickets/{id}  (DTO Patch / JSON Patch)  (resursbaserat sätt)
    // { "closedAt": "2026-02-10T12:15" }


    // TODO: Implementra följande som övning

    // # Tilldela ärende
    // POST /api/tickets/{id}/assign        
    
    // # Stäng ärende
    // POST /api/tickets/{id}/close

    // # Återöppna ärende
    // POST /api/tickets/{id}/delete

    // # Återöppna ärende
    // POST /api/tickets/{id}/reopen

    // # Eskalera ärende
    // POST /api/tickets/{id}/escalate

    // # Kommentera ärende
    // POST /api/tickets/{id}/add-comment

    // # Ändra prioritet
    // POST /api/tickets/{id}/change-priority

    // Lägg till endpoints för att hämta ut info
    // GET /api/tickets/{id}
    // GET /api/open-tickets


    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> Create(CreateTicketDto createTicketDto)
    {
        // 1 - Skapa ticket
        var ticket = await _ticketService.CreateTicketAsync(
            title: createTicketDto.Title,
            descrption: createTicketDto.Description);

        // 2 - Mappa ticket till DTO
        var response = new TicketDto(
            Id: ticket.Id,
            Title: ticket.Title,
            Description: ticket.Description,
            CreatedAt: ticket.CreatedAt,
            AssignedTo: ticket.AssignedTo,
            Comments: ticket.GetComments()
            .Select(c => new CommentDto(c, DateTime.UtcNow))
            .ToList(), Priority: ticket.Priority);

        return Created(string.Empty, response); // 201 Created
    }

    // GET /api/tickets
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TicketDto>>> GetAll()
    {
        // 1 - Skapa ticket
        var tickets = await _ticketService.GetTicketsAsync();
        
        var response = tickets.Select(ticket => new TicketDto(
            Id: ticket.Id,
            Title: ticket.Title,
            Description: ticket.Description,
            CreatedAt: ticket.CreatedAt, 
            AssignedTo: ticket.AssignedTo,
            Comments: ticket.GetComments()
            .Select(c => new CommentDto(c, DateTime.UtcNow))
            .ToList(), Priority: ticket.Priority));

        return Ok(response); // 200 OK
    }

    // GET /api/tickets/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDto>> Get(int id)
    {
        // 1 - Skapa ticket
        var ticket = await _ticketService.GetTicketAsync(id);

        if (ticket is null) return NotFound(); // 404 Not Found

        var response = new TicketDto(
            Id: ticket.Id,
            Title: ticket.Title,
            Description: ticket.Description,
            CreatedAt: ticket.CreatedAt,
            AssignedTo: ticket.AssignedTo,
            Comments: ticket.GetComments()
            .Select(c => new CommentDto(c, DateTime.UtcNow))
            .ToList(), Priority: ticket.Priority);

        return Ok(response); // 200 OK
    }

    // POST /api/tickets/{id}/assign
    [HttpPost("{id}/assign")]
    public async Task<IActionResult> Assign(int id, TicketDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.AssignedTo))
            return BadRequest("AssignedTo cannot be empty");

        await _ticketService.AssignTicketAsync(id, dto.AssignedTo);
        return NoContent();
    }

    [HttpPost("{id}/close")]
    public async Task<IActionResult> Close(int id)
    {
        await _ticketService.CloseTicketAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/reopen")]
    public async Task<IActionResult> Reopen(int id)
    {
        await _ticketService.ReopenTicketAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/escalate")]
    public async Task<IActionResult> Escalate(int id)
    {
        await _ticketService.EscalateTicketAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/add-comment")]
    public async Task<IActionResult> AddComment(int id, CommentDto dto)
    {
        await _ticketService.AddCommentAsync(id, dto.Comment);
        return NoContent();
    }

    [HttpPost("{id}/change-priority")]
    public async Task<IActionResult> ChangePriority(int id, ChangePriorityDto dto)
    {
        await _ticketService.ChangePriorityAsync(id, dto.Priority);
        return NoContent();
    }

    // Delete

    // Patch (uppdaterar)

    // Put (ersätter eller skapar)
}
