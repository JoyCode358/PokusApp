using BookingApi.Data;
using Microsoft.EntityFrameworkCore;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*pre pracu s inmemory DB*/
//builder.Services.AddDbContext<ApiContext>(option => option.UseInMemoryDatabase("MyTestBookingDB"));

/*pre pracu s Microsoft Sql DB*/
builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

