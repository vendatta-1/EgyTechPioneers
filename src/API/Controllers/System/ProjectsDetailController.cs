using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsDetailController : ControllerBase
{
    private readonly IProjectsDetail _service;

    public ProjectsDetailController(IProjectsDetail service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<IResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await _service.GetAsync(id, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken ct)
    {
        var result = await _service.GetAllAsync(ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("by-master/{masterId:guid}")]
    public async Task<IResult> GetByMaster(Guid masterId, CancellationToken ct)
    {
        var result = await _service.GetByMasterIdAsync(masterId, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpPost]
    public async Task<IResult> Create(ProjectsDetailDto dto, CancellationToken ct)
    {
        var result = await _service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/ProjectsDetail/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, ProjectsDetailDto dto, CancellationToken ct)
    {
        dto.Id = id;
        var result = await _service.UpdateAsync(id, dto, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _service.DeleteAsync(id, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }
}