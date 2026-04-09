using Microsoft.EntityFrameworkCore;
using Seguro.Application.Interfaces;
using Seguro.Application.Services;
using Seguro.Infrastructure.Data;
using Seguro.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();

builder.Services.AddDbContext<SeguroDbContext>(opt =>
    opt.UseInMemoryDatabase("SeguroDb"));

builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<SeguroService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{   
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
