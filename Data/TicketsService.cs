using BlazorExp.Entity;
using BlazorExp.Services;

namespace BlazorExp.Data;

public class TicketsService
{
    private readonly IRepository _repository;

    public TicketsService(IRepository repository) => 
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<IEnumerable<Ticket>> GetTickets()
    {
        return await _repository.FetchTickets();
        // return null;
    }

    public async Task SaveTicket(Ticket ticket)
    {
        await _repository.SaveTicket(ticket);
    }
}