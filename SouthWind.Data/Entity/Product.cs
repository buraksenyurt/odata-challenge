namespace SouthWind.Data.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal ListPrice { get; set; }
    public bool InStock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<Order> Orders { get; set; }
}