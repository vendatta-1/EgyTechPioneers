using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
public class SkillDevelopmentController(ISkillDevelopment service) : ControllerBase
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

    [HttpGet("notactive")]
    public async Task<IResult> GetNotActive(CancellationToken ct)
    {
        var result = await service.GetNotActiveAsync(ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpPost]
    public async Task<IResult> Create([FromForm] SkillDevelopmentDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/SkillDevelopment/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] SkillDevelopmentDto dto, CancellationToken ct)
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

    [HttpGet("{id:guid}/attachment")]
    public async Task<IActionResult> GetAttachment(Guid id, CancellationToken ct)
    {
        var result = await service.GetAttachmentsAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.File!, result.Value.ContentType ?? "application/octet-stream");
    }
}
