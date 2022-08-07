using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

exempleBasicEndPoint();
exempleBodyEndPoint();
exempleEndPointUrl();
exempleEndPointHeader();


app.Run();


void exempleBasicEndPoint()
{
    app.MapGet("/", () => "Hello World! 5");
    app.MapPost("/", () => new { name = "Reinan", age = "23" });
    app.MapGet("/AddHeader", (HttpResponse response) =>
{
    response.Headers.Add("Teste", "Reinan de Souza");
    return new { name = "Reinan", age = "23" };
});
}

void exempleBodyEndPoint()
{
    app.MapPost("/saveproduct", (Product product) =>
    {
        String message = product.code + " - " + product.name;

        return message;

    });
}

void exempleEndPointUrl()
{
    // https://localhost:3000/getproduct/?dateStart=x&dateend=y
    app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string? dateEnd) =>
    {

        return dateStart + " - " + dateEnd;
    });

    // https://localhost:3000/getproduct/30
    app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
    {
        return code;

    });
}

void exempleEndPointHeader()
{
    app.MapGet("/getproductbyheader", (HttpRequest request) =>
    {
        return request.Headers["product-code"].ToString();
    });
}

