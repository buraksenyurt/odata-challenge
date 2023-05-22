using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SouthWind.Data;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly SouthWindDbContext _dbContext;
    public CategoryController(SouthWindDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_dbContext.Categories.AsQueryable());
    }
}