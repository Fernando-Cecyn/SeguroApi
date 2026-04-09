using Microsoft.EntityFrameworkCore;
using Seguro.Application.Interfaces;
using Seguro.Application.Services;
using Seguro.Infrastructure.Data;
using Seguro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SeguroDbContext>(opt =>
    opt.UseInMemoryDatabase("SeguroDb"));

builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<SeguroService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();