using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
public class StudentDataController(IStudentData service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IResult> Get(Guid id, CancellationToken ct)
    {
        var result = await service.GetAsync(id, ct);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken ct)
    {
        var result = await service.GetAllAsync(ct);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    [HttpGet("not-active")]
    public async Task<IResult> GetNotActive(CancellationToken ct)
    {
        var result = await service.GetNotActiveAsync(ct);
        return result.Match(
            Results.Ok,
            ApiResults.Problem
        );
    }

    [HttpGet("by-email/{email}")]
    public async Task<IResult> GetByEmail(string email, CancellationToken ct)
    {
        var result = await service.GetByEmailAsync(email, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("by-group/{groupId:guid}")]
    public async Task<IResult> GetByGroup(Guid groupId, CancellationToken ct)
    {
        var result = await service.GetByGroupIdAsync(groupId, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpGet("graduated")]
    public async Task<IResult> GetGraduated(CancellationToken ct)
    {
        var result = await service.GetGraduatedStudentsAsync(ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] StudentDataDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/StudentData/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromBody] StudentDataDto dto, CancellationToken ct)
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
