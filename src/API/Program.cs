using API.Extensions;
using Common;
using Infrastructure;
using Logic;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAcademy(builder.Configuration);

builder.Services.AddCommonInjection(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRepositoryInjection(builder.Configuration);
builder.Services.AddLogic(builder.Configuration);
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
    
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
