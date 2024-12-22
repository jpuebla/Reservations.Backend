using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reservations.backend.Data.Mappings;
using Reservations.Backend.DataEntity.EFModels.Context;
using Reservations.Backend.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbDataContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ServiceDependenciesExtension.AddServiceCollections(builder.Services);
MappingsExtension.AddMappings(builder.Services);

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Reservations API", Version = "v1" });    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
