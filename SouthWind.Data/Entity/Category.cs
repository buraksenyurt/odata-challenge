namespace SouthWind.Data.Entity;
public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }
}