using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EduContactResultController(IEduContactResult service) : ControllerBase
{
    private readonly IEduContactResult _service = service;

    [HttpGet("{id:guid}")]
    public async Task<IResult> Get(Guid id, CancellationToken ct)
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

    [HttpPost]
    public async Task<IResult> Create([FromForm] EduContactResultDto dto, CancellationToken ct)
    {
        var result = await _service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/EduContactResult/{data}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] EduContactResultDto dto, CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _service.DeleteAsync(id, ct);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpGet("student/{studentId:guid}")]
    public async Task<IResult> GetByStudent(Guid studentId, CancellationToken ct)
    {
        var result = await _service.GetByStudentIdAsync(studentId, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("range")]
    public async Task<IResult> GetByDateRange([FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct)
    {
        var result = await _service.GetByDateRangeAsync(from, to, ct);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("{id:guid}/file")]
    public async Task<IActionResult> GetAttachment(Guid id, CancellationToken ct)
    {
        var result = await _service.GetAttachmentAsync(id, ct);
        if (result.IsFailure) return NotFound(result.Error.Description);
        return File(result.Value.Stream!, result.Value.ContentType ?? "application/octet-stream",result.Value.FileName);
    }
}
