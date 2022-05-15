using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorExp.Entity;

namespace BlazorExp.GraphQL
{
    public class AddTicketPayload
    {
        public Ticket Ticket { get; set; }

        public AddTicketPayload(Ticket ticket) => Ticket = ticket;
    }
}