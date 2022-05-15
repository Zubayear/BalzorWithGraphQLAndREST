using BlazorExp.Entity;

namespace BlazorExp.Services;

public interface IRepository
{
    Task<IEnumerable<Ticket>> FetchTickets();
    Task<Ticket> FetchTicket(string id);
    Task SaveTicket(Ticket ticket);
    Task ModifyTicket(string id, Ticket ticket);
    Task RemoveTicket(string id);
}