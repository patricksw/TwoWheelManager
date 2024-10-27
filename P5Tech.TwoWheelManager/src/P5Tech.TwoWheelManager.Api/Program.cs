using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P5Tech.TwoWheelManager.Api.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DeclareConfiguration(builder.Configuration);
builder.Services.DeclareServices();

builder.Host
       .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
       .ReadFrom
       .Configuration(hostingContext.Configuration)
       .WriteTo
       .Console());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();