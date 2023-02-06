using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Infrastructure.AspNetCore.Middleware.Error;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add fluent validation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UserRequestDtoValidator));
builder.Services.AddFluentValidationAutoValidation();

//Add exception handlers
builder.Services.AddTransient<ExceptionHandlerFactory>();
builder.Services.AddTransient<IExceptionHandler, DefaultExceptionHandler>();
builder.Services.AddTransient<IExceptionHandler, FluentValidationExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();
