namespace SouthWind.Data.Entity;

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public int ProductID { get; set; }
    public Product Product { get; set; }
}