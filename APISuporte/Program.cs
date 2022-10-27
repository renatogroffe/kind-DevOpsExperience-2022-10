using FluentValidation;
using FluentValidation.AspNetCore;
using APISuporte.Data;
using APISuporte.Models;
using APISuporte.Services;
using APISuporte.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChamadosRepository>();
builder.Services.AddScoped<ChamadosService>();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<RequisicaoSuporte>, RequisicaoSuporteValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation($"MongoDB Database = {app.Configuration["MongoDB:Database"]}");
app.Logger.LogInformation($"MongoDB Collection = {app.Configuration["MongoDB:Collection"]}");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();