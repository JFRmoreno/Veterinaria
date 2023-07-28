using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<VetarinariaContext>(builder.Configuration.GetConnectionString("cnVeterinaria"));

var app = builder.Build();

app.MapGet ("/dbconexion", async([FromServices] VetarinariaContext dbcontext) =>  
{
    dbcontext.Database.EnsureCreated(); 
    return Results.Ok("Base de datos Creada");
});
app.Run();
