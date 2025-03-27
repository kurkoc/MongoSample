using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoSample.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDB(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "it works!");

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