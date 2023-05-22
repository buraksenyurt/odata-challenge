namespace SouthWind.Data.Entity;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}