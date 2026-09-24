var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
                         {
                             options.AddDefaultPolicy ( policity => 
                                                       {
                                                           policity
                                                               .AllowAnyOrigin()
                                                               .AllowAnyHeader()
                                                               .AlLowAnyMethod();
                                                       }
                                                      )
                         })

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

var port = Enviroment.GetEnviromentVariable("Port")??"1000",
app.Run($"http://0.0.0.0:(port)");
app.Run();
