var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint zwracaj¹cy trasê
app.MapGet("/route", () =>
{
    // Generowanie przyk³adowej trasy
    var route = Enumerable.Range(1, 5).Select(index =>
        new RoutePoint
        (
            Latitude: 49.656390 + (index * 0.001),
            Longitude: 19.159260 + (index * 0.001)
        ))
        .ToArray();
    return route;
})
.WithName("GetRoute")
.WithOpenApi();

app.Run();

// Rekord reprezentuj¹cy punkt trasy
record RoutePoint(double Latitude, double Longitude);
