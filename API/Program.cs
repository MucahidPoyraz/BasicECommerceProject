using DAL.Context.EF;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDalExtension(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<BECPContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
