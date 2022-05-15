using BlazorExp.Entity;

namespace BlazorExp.GraphQL;

public class TicketType : ObjectType<Ticket>
{
    protected override void Configure(IObjectTypeDescriptor<Ticket> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Type<StringType>();
        
        descriptor
            .Field(f => f.Stadium)
            .Type<StringType>();
        
        descriptor
            .Field(f => f.MatchTime)
            .Type<StringType>();
        
        descriptor
            .Field(f => f.TicketName)
            .Type<StringType>();
        
        descriptor
            .Field(f => f.TicketPrice)
            .Type<DecimalType>();
    }
}