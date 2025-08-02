using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
public class ProjectsMasterController(IProjectsMaster service) : ControllerBase
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
    public async Task<IResult> Create([FromForm] ProjectsMasterDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/ProjectsMaster/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] ProjectsMasterDto dto, CancellationToken ct)
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

    [HttpGet("{id:guid}/file")]
    public async Task<IActionResult> GetFile(Guid id, CancellationToken ct)
    {
        var result = await service.GetProjectFileAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.File, result.Value.ContentType ?? "application/octet-stream");
    }

    [HttpGet("{id:guid}/resource")]
    public async Task<IActionResult> GetResource(Guid id, CancellationToken ct)
    {
        var result = await service.GetProjectResourcesAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.File, result.Value.ContentType ?? "application/octet-stream");
    }


    [HttpGet("academy/{academyId:guid}")]
    public async Task<IResult> GetByAcademy(Guid academyId, CancellationToken ct)
    {
        var result = await service.GetByAcademyIdAsync(academyId, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("branch/{branchId:guid}")]
    public async Task<IResult> GetByBranch(Guid branchId, CancellationToken ct)
    {
        var result = await service.GetByBranchIdAsync(branchId, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("count/academy/{academyId:guid}")]
    public async Task<IResult> CountByAcademy(Guid academyId, CancellationToken ct)
    {
        var result = await service.CountByAcademyAsync(academyId, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("range")]
    public async Task<IResult> GetByRange([FromQuery] DateOnly start, [FromQuery] DateOnly end, CancellationToken ct)
    {
        var result = await service.GetByDateRangeAsync(start, end, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }
}
