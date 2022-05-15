using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorExp.Entity;
using BlazorExp.Services;

namespace BlazorExp.GraphQL
{
    public class Mutation 
    {
        public async Task<AddTicketPayload> AddTicket(AddTicketInput input, [Service] IRepository repository)
        {
            var ticket = new Ticket
            {
                Id = Guid.NewGuid().ToString(),
                TicketName = input.TicketName,
                TicketPrice = input.TicketPrice,
                Stadium = input.Stadium,
                MatchTime = DateTimeOffset.Now.LocalDateTime.ToString()
            };
            
            await repository.SaveTicket(ticket);
            
            return new AddTicketPayload(ticket);
        }
    }
}