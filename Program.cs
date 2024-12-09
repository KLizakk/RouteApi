using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Konfiguracja hosta do nas�uchiwania na porcie 5000 (lub innym) na HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    // Ustawienie nas�uchiwania na porcie 5000, na dowolnym interfejsie
    options.Listen(IPAddress.Any, 5000);  // Nas�uchiwanie na porcie 5000 (na wszystkich interfejsach)
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
    // Trasa z Bielska-Bia�ej na Szyndzielni�
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia�a - Rynek (start)
        new RoutePoint(49.828172, 19.086974),  // Kolejka na Szyndzielni�
        new RoutePoint(49.840806, 19.086923),  // Pod szczytem Szyndzielni
        new RoutePoint(49.844586, 19.086735),  // Szyndzielnia (szczyt)
        new RoutePoint(49.820073, 19.048364)   // Powr�t do Bielska-Bia�ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia�ej na Szyndzielni�" });
})
.WithName("Route1")
.WithOpenApi();

app.MapGet("/route2", () =>
{
    // Trasa z Bielska-Bia�ej na Skrzyczne
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia�a (start)
        new RoutePoint(49.840023, 19.073134),  // Dolna stacja kolejki na Skrzyczne
        new RoutePoint(49.860651, 19.122707),  // Na Skrzycznem - punkt po�redni
        new RoutePoint(49.875077, 19.136982),  // Skrzyczne (szczyt)
        new RoutePoint(49.820073, 19.048364)   // Powr�t do Bielska-Bia�ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia�ej na Skrzyczne" });
})
.WithName("Route2")
.WithOpenApi();
app.Run();

app.MapGet("/route3", () =>
{
    // Trasa z Bielska-Bia�ej na Hal� Miziow�
    var route = new[]
    {
        new RoutePoint(49.820073, 19.048364),  // Bielsko-Bia�a (start)
        new RoutePoint(49.835179, 19.091275),  // Przej�cie przez las
        new RoutePoint(49.850216, 19.137736),  // Prze��cz Siod�o
        new RoutePoint(49.854948, 19.159312),  // Hala Miziowa (schronisko)
        new RoutePoint(49.820073, 19.048364)   // Powr�t do Bielska-Bia�ej
    };
    return Results.Ok(new { Route = route, Description = "Trasa z Bielska-Bia�ej na Hal� Miziow�" });
})
.WithName("Route3")
.WithOpenApi();

// Rekord reprezentuj�cy punkt trasy
record RoutePoint(double Latitude, double Longitude);
