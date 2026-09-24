var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();

app.MapGet("/", () => 
{
    return "API Venta de abarrotes funcionando";
});

app.MapGet("/api/VentaAbarrotes", () =>
{
    return Results.Ok(new[]
    {
        new {
            id = 1, 
            codigo = "P001",
            nombres = "Arroz"
        },
        new {
            id = 2, 
            codigo = "P002",
            nombres = "Fideos"
        }
    });
}); 

app.Run();