using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgramsContentMasterController(IProgramsContentMaster service) : ControllerBase
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
    public async Task<IResult> Create([FromForm] ProgramsContentMasterDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/ProgramsContentMaster/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] ProgramsContentMasterDto dto, CancellationToken ct)
    {
        dto.Id = id;
        var result = await service.UpdateAsync(id, dto, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await service.DeleteAsync(id, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpGet("{id:guid}/material")]
    public async Task<IActionResult> DownloadMaterial(Guid id, CancellationToken ct)
    {
        var result = await service.GetScientificMaterialAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream, result.Value.ContentType ?? "application/octet-stream",result.Value.FileName);
    }
}