using API.Extensions;
using API.Filters;
using API.Hubs;
using Common;
using Infrastructure;
using Logic;
using Logic.Interfaces.Cache;
using Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalCacheFilter>();
}); 
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


app.UseCors("AllowAll");
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();
app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();
