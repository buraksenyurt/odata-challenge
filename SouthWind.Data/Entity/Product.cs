namespace SouthWind.Data.Entity;

public class Product
{
    public string ProductID { get; set; }
    public string Name { get; set; }
    public decimal ListPrice { get; set; }
    public bool InStock { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public List<Order> Orders { get; set; }
}