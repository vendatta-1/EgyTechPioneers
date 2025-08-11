using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
public class TeacherDataController(ITeacherData service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IResult> Get(Guid id, CancellationToken ct)
    {
        var result = await service.GetAsync(id, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken ct)
    {
        var result = await service.GetAllAsync(ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("not-active")]
    public async Task<IResult> GetNotActive(CancellationToken ct)
    {
        var result = await service.GetNotActiveAsync(ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("by-branch/{branchId:guid}")]
    public async Task<IResult> GetByBranch(Guid branchId, CancellationToken ct)
    {
        var result = await service.GetByBranchAsync(branchId, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("by-governorate/{governorateId:guid}")]
    public async Task<IResult> GetByGovernorate(Guid governorateId, CancellationToken ct)
    {
        var result = await service.GetByGovernorateAsync(governorateId, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("by-city/{cityId:guid}")]
    public async Task<IResult> GetByCity(Guid cityId, CancellationToken ct)
    {
        var result = await service.GetByCityAsync(cityId, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpPost]
    public async Task<IResult> Create([FromForm] TeacherDataDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/TeacherData/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] TeacherDataDto dto, CancellationToken ct)
    {
        var result = await service.UpdateAsync(id, dto, ct);
        return result.Match(
            Results.NoContent,
            ApiResults.Problem
        );
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await service.DeleteAsync(id, ct);
        return result.Match(
            Results.NoContent,
            ApiResults.Problem
        );
    }
}
