using Taller1IDWM.Src.Extensions;
using Taller1IDWM.Src.Repositories.Implements;
using Taller1IDWM.Src.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
app.ConfigureApp();
app.Run();
