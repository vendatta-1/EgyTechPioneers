using API.Extensions;
using API.Filters;
using API.Hubs;
using Common;
using Infrastructure;
using Logic;
using Logic.Interfaces.Cache;
using Microsoft.AspNetCore.Http.Features;
using Repositories;
using Repositories.Seeds;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.Limits.MaxRequestBodySize = int.MaxValue;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue; // Allow very large files
    options.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryInjection(builder.Configuration);
builder.Services.AddAcademy(builder.Configuration);

builder.Services.AddCommonInjection(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddLogic(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
    app.RoleSeed();

}

app.UserCreate();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

// app.UseMiddleware<MimeExtensionMiddleware>();
app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();
