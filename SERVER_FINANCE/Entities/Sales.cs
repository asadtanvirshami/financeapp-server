namespace FinanceServer.Api.Entities;

public class Sales
{
    public int Id { get; set; }
    public required decimal Price { get; set; }
    public required string Payment { get; set; }
    public required string Platform { get; set; }
    public required string Client { get; set; }
    public DateOnly Date { get; set; }

    public int UserId { get; set; }

    public Users? User { get; set; }
}