using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExp.GraphQL
{
    public record AddTicketInput(string TicketName, decimal TicketPrice, string Stadium);
}