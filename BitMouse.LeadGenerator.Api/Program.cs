using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Infrastructure.AspNetCore.Middleware.Error;
using BitMouse.LeadGenerator.Service.Settings;
using BitMouse.LeadGenerator.Service.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddTransient<IUserService, UserService>();

// Add settings to the container
builder.Services.Configure<IntegrationApiSettings>(builder.Configuration.GetSection(nameof(IntegrationApiSettings)));
builder.Services.AddScoped(config => config.GetService<IOptionsSnapshot<IntegrationApiSettings>>()!.Value);

// Add http clients to the container
builder.Services.AddHttpClient();

// Add fluent validation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UserRequestDtoValidator));
builder.Services.AddFluentValidationAutoValidation();

// Add exception handlers
builder.Services.AddTransient<ExceptionHandlerFactory>();
builder.Services.AddTransient<IExceptionHandler, DefaultExceptionHandler>();
builder.Services.AddTransient<IExceptionHandler, FluentValidationExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
