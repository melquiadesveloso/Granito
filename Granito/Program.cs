using GranitoApi.Business.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Granito API - Calcular",
                Version = "v1",
                Description = "Avaliação Granito - Calcular",
                Contact = new OpenApiContact
                {
                    Name = "Melquíades de Souza Veloso - Projeto",
                    Url = new Uri("https://github.com/melquiadesveloso/Granito")
                }
            });
});
builder.Host.UseSerilog();
builder.Services.AddRegisterLogger();

builder.Services.AddRegister();




var app = builder.Build();



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
