using Progracion6_DesarrolloDeContenidos.Extensions;
using Progracion6_DesarrolloDeContenidos.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<BasicAuthenticationHandlerMiddleware>("Test");

app.UseHttpsRedirection();

app.UseAuthorization();
//ErrorHandlerCreado
app.UseErrorHandler();

app.MapControllers();

app.Run();
