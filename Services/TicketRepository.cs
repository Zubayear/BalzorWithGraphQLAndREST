using Amazon.DynamoDBv2.DataModel;
using BlazorExp.Entity;

namespace BlazorExp.Services;

public class TicketRepository : IRepository
{
    private readonly IDynamoDBContext _dynamoDbContext;

    public TicketRepository(IDynamoDBContext dynamoDbContext) => 
        this._dynamoDbContext = dynamoDbContext ?? throw new ArgumentNullException(nameof(dynamoDbContext));
    
    async Task<Ticket> IRepository.FetchTicket(string id)
    {
        return await _dynamoDbContext.LoadAsync<Ticket>(id);
    }

    async Task<IEnumerable<Ticket>> IRepository.FetchTickets()
    {
        return await _dynamoDbContext.ScanAsync<Ticket>(default).GetRemainingAsync();
    }

    async Task IRepository.ModifyTicket(string id, Ticket ticket)
    {
        var ticketFromRepo = await _dynamoDbContext.LoadAsync<Ticket>(id);
        if (ticketFromRepo == null)
        {
            throw new InvalidOperationException();
        }
        ticketFromRepo.Stadium = ticket.Stadium;
        ticketFromRepo.MatchTime = DateTimeOffset.Now.LocalDateTime.ToString();
        ticketFromRepo.TicketName = ticket.TicketName;
        ticketFromRepo.TicketPrice = ticket.TicketPrice;
        await _dynamoDbContext.SaveAsync(ticketFromRepo);
    }

    async Task IRepository.RemoveTicket(string id)
    {
        await _dynamoDbContext.DeleteAsync<Ticket>(id);
    }

    async Task IRepository.SaveTicket(Ticket ticket)
    {
        await _dynamoDbContext.SaveAsync(ticket);
    }
}