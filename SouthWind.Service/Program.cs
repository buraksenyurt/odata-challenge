using Microsoft.AspNetCore.OData;
using SouthWind.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataContext(configuration);

builder.Services.AddControllers().AddOData(
    options => options
                .Select()
                .Filter()
                .Count()
                .OrderBy()
                .Expand()
                .SetMaxTop(100)
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
