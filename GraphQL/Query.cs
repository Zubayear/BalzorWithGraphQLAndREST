using BlazorExp.Entity;
using BlazorExp.Services;

namespace BlazorExp.GraphQL;

public class Query
{
    public async Task<Ticket> GetTicketById([Service] IRepository repository, string id) => 
        await repository.FetchTicket(id);

    public async Task<IEnumerable<Ticket>> GetAllTickets([Service] IRepository repository) =>
        await repository.FetchTickets();
}