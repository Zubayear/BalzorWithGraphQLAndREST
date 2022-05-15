using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExp.GraphQL
{
    public class AddTicketPayloadType : ObjectType<AddTicketPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddTicketPayload> descriptor)
        {
            descriptor.Field(f => f.Ticket)
                .Type<TicketType>();
        }
    }
}