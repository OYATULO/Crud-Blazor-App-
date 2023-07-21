using Api_Company.Context;
using Api_Company.IData;
using Api_Company.IData.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x=>x.UseNpgsql(builder.Configuration.GetConnectionString("DefualtCon")));
builder.Services.AddScoped<ICompany, DataCompany>();
builder.Services.AddScoped<IContact, DataContacts>();
builder.Services.AddScoped<IComunication, DataCommunication>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy =>policy
    .WithOrigins("https://localhost:7063/", "http://localhost:7063/")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType).AllowAnyOrigin()
   
);
app.UseAuthorization();

app.MapControllers();

app.Run();
