using Amazon.DynamoDBv2.DataModel;
using BlazorExp.Entity;
using BlazorExp.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly IRepository repository;

    public TicketsController(IRepository repository) => this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

    [HttpPost(Name = nameof(CreateTicket))]
    public async Task<IActionResult> CreateTicket(Ticket ticket) 
    {
        var id = Guid.NewGuid().ToString();
        ticket.Id = id;
        ticket.MatchTime = DateTimeOffset.Now.LocalDateTime.ToString();
        await repository.SaveTicket(ticket);
        return CreatedAtRoute(nameof(GetTicketById), new {id = id}, ticket);
    }

    [HttpGet("{id}", Name = nameof(GetTicketById))]
    public async Task<IActionResult> GetTicketById([FromRoute] string id) 
    {
        return Ok(await repository.FetchTicket(id));
    } 

    [HttpDelete("{id}", Name = nameof(RemoveTicketById))]
    public async Task<IActionResult> RemoveTicketById([FromRoute] string id) 
    {
        await repository.RemoveTicket(id);
        return NoContent();
    }


    [HttpPut("{id}", Name = nameof(UpdateTicketById))]
    public async Task<IActionResult> UpdateTicketById([FromRoute] string id, Ticket ticket) 
    {
        try
        {
            await repository.ModifyTicket(id, ticket);
        }
        catch (System.Exception ex)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet(Name = nameof(GetTickets))]
    public async Task<IActionResult> GetTickets()
    {
        return Ok(await repository.FetchTickets());
    }
}