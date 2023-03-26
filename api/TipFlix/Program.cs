using Application.Handler;
using Application.Interfaces;
using Application.Mapper;
using AutoMapper;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions
                           .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// PostgreSQL
string? postgreSqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(postgreSqlConnection));

// MovieDb API Client
builder.Services.AddScoped<IMovieClient, MovieDbClient>();

// Handler
builder.Services.AddScoped<IHandler, Handler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
