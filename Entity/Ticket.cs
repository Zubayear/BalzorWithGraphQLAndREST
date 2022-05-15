using Amazon.DynamoDBv2.DataModel;

namespace BlazorExp.Entity;

[DynamoDBTable("tickets")]
public class Ticket
{
    [DynamoDBHashKey("id")] public string? Id { get; set; }

    [DynamoDBProperty("ticketName")] public string? TicketName { get; set; }

    [DynamoDBProperty("ticketPrice")] public decimal TicketPrice { get; set; }

    [DynamoDBProperty("stadium")] public string? Stadium { get; set; }

    [DynamoDBProperty("matchTime")] public string? MatchTime { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(TicketName)}: {TicketName}, {nameof(TicketPrice)}: {TicketPrice}, {nameof(Stadium)}: {Stadium}, {nameof(MatchTime)}: {MatchTime}";
    }
}