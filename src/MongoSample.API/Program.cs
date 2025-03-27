using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoSample.Application.Services;
using MongoSample.Application.Services.Abstractions;
using MongoSample.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDB(builder.Configuration);

builder.Services.AddBusinessServices();

var app = builder.Build();

app.MapGet("/", () => "it works!");

app.MapGet("books", async ([FromServices]IBookService bookService) => Results.Ok(await bookService.GetBooks()));

app.MapGet("build", async ([FromServices] IMongoDatabase database) =>
{
    var command = new BsonDocument("buildInfo", 1);
    var result = await database.RunCommandAsync<BsonDocument>(command);
    var json = result.ToJson();
    return Results.Content(json, "application/json");
});

app.MapGet("status", async ([FromServices] IMongoDatabase database) =>
{
    var command = new BsonDocument("serverStatus", 1);
    var result = await database.RunCommandAsync<BsonDocument>(command);
    var json = result.ToJson();
    return Results.Content(json, "application/json");
});

app.Run();