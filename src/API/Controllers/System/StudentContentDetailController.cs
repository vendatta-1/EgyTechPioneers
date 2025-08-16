using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentContentDetailController(IStudentContentDetail service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IResult> Get(Guid id, CancellationToken ct)
    {
        var result = await service.GetAsync(id, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken ct)
    {
        var result = await service.GetAllAsync(ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpPost]
    public async Task<IResult> Create([FromForm] StudentContentDetailDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/StudentContentDetail/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] StudentContentDetailDto dto, CancellationToken ct)
    {
        var result = await service.UpdateAsync(id, dto, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await service.DeleteAsync(id, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("task/{id:guid}")]
    public async Task<IResult> GetSessionTask(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionTasksAsync(id, ct);
        return result.Match(
            data => Results.File(data.Stream!, data.ContentType ?? "application/octet-stream", data.FileName),
            ApiResults.Problem
        );
    }

    [HttpGet("project/{id:guid}")]
    public async Task<IResult> GetSessionProject(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionProjectAsync(id, ct);
        return result.Match(
            data => Results.File(data.Stream!, data.ContentType ?? "application/octet-stream",data.FileName),
            ApiResults.Problem
        );
    }

    [HttpGet("quiz/{id:guid}")]
    public async Task<IResult> GetSessionQuiz(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionQuizAsync(id, ct);
        return result.Match(
            data => Results.File(data.Stream!, data.ContentType ?? "application/octet-stream", data.FileName),
            ApiResults.Problem
        );
    }
}
