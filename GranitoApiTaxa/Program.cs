using Microsoft.OpenApi.Models;

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
                                                Title = "Granito API Taxa",
                                                Version = "v1",
                                                Description = "Avalia��o Granito - Capturar Taxa",
                                                Contact = new OpenApiContact
                                                {
                                                    Name = "Melqu�ades de Souza Veloso - Projeto",
                                                    Url = new Uri("https://github.com/melquiadesveloso/Granito")
                                                }
                                            });
                                });

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
