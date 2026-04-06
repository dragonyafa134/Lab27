var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "ПРИВЕТ ОТ ИСП 233 автор Dragonyafa");

app.Run();
