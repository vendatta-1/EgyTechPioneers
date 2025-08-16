using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgramsContentDetailController(IProgramsContentDetail service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IResult> GetById(Guid id, CancellationToken ct)
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
    public async Task<IResult> Create([FromForm] ProgramsContentDetailDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/ProgramsContentDetail/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] ProgramsContentDetailDto dto, CancellationToken ct)
    {
        var result = await service.UpdateAsync(id, dto, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await service.DeleteAsync(id, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpGet("{id:guid}/tasks")]
    public async Task<IActionResult> GetTasks(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionTasksAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream, result.Value.ContentType ?? "application/octet-stream", result.Value.FileName);
    }

    [HttpGet("{id:guid}/project")]
    public async Task<IActionResult> GetProject(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionProjectAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream, result.Value.ContentType ?? "application/octet-stream", result.Value.FileName);
    }

    [HttpGet("{id:guid}/material")]
    public async Task<IActionResult> GetMaterial(Guid id, CancellationToken ct)
    {
        var result = await service.GetScientificMaterialAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream, result.Value.ContentType ?? "application/octet-stream", result.Value.FileName);
    }

    [HttpGet("{id:guid}/quiz")]
    public async Task<IActionResult> GetQuiz(Guid id, CancellationToken ct)
    {
        var result = await service.GetSessionQuizAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream, result.Value.ContentType ?? "application/octet-stream", result.Value.FileName);
    }
}
