namespace BlazorExp.GraphQL;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(f => f.GetAllTickets(default!))
            .Type<TicketType>();

        descriptor
            .Field(f => f.GetTicketById(default!, default!))
            .Type<TicketType>();
    }
}