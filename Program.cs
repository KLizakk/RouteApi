using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Konfiguracja hosta do nas³uchiwania na porcie 5000 (lub innym) na HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    // Ustawienie nas³uchiwania na porcie 5000, na dowolnym interfejsie
    options.Listen(IPAddress.Any, 5000);  // Nas³uchiwanie na porcie 5000 (na wszystkich interfejsach)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Zakomentowana linia, bo nie potrzebujemy przekierowania na HTTPS
// app.UseHttpsRedirection();

app.MapGet("/route1", () =>
{
    // Trasa z Bielska-Bia³ej na Szyndzielniê
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia³a - Rynek (start)
        new RoutePoint(49.828172, 19.086974),  // Kolejka na Szyndzielniê
        new RoutePoint(49.840806, 19.086923),  // Pod szczytem Szyndzielni
        new RoutePoint(49.844586, 19.086735),  // Szyndzielnia (szczyt)
        new RoutePoint(49.820073, 19.048364)   // Powrót do Bielska-Bia³ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia³ej na Szyndzielniê" });
})
.WithName("Route1")
.WithOpenApi();

app.MapGet("/route2", () =>
{
    // Trasa z Bielska-Bia³ej na Skrzyczne
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia³a (start)
        new RoutePoint(49.840023, 19.073134),  // Dolna stacja kolejki na Skrzyczne
        new RoutePoint(49.860651, 19.122707),  // Na Skrzycznem - punkt poœredni
        new RoutePoint(49.875077, 19.136982),  // Skrzyczne (szczyt)
        new RoutePoint(49.820073, 19.048364)   // Powrót do Bielska-Bia³ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia³ej na Skrzyczne" });
})
.WithName("Route2")
.WithOpenApi();
app.Run();

app.MapGet("/route3", () =>
{
    // Trasa z Bielska-Bia³ej na Halê Miziow¹
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia³a (start)
        new RoutePoint(49.835179, 19.091275),  // Przejœcie przez las
        new RoutePoint(49.850216, 19.137736),  // Prze³êcz Siod³o
        new RoutePoint(49.854948, 19.159312),  // Hala Miziowa (schronisko)
        new RoutePoint(49.820073, 19.048364)   // Powrót do Bielska-Bia³ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia³ej na Halê Miziow¹" });
})
.WithName("Route3")
.WithOpenApi();

// Rekord reprezentuj¹cy punkt trasy
record RoutePoint(double Latitude, double Longitude);
