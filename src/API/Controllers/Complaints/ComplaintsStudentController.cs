using Dtos.Complaints;
using Logic.Interfaces.Complaints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;

namespace API.Controllers.Complaints;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ComplaintsStudentController(IComplaintsStudent service) : ControllerBase
{
    private readonly IComplaintsStudent _service = service;

    [HttpGet("{id:guid}")]
    public async Task<IResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetAsync(id, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync(cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpPost]
    public async Task<IResult> Create([FromForm] ComplaintsStudentDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/ComplaintsStudent/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] ComplaintsStudentDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(id, dto, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(id, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpGet("student/{studentId:guid}")]
    public async Task<IResult> GetByStudentId(Guid studentId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByStudentIdAsync(studentId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("status/{statusId:guid}")]
    public async Task<IResult> GetByStatusId(Guid statusId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByStatusIdAsync(statusId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("range")]
    public async Task<IResult> GetByDateRange([FromQuery] DateOnly from, [FromQuery] DateOnly to, CancellationToken cancellationToken)
    {
        var result = await _service.GetByDateRangeAsync(from, to, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("count/{statusId:guid}")]
    public async Task<IResult> CountByStatus(Guid statusId, CancellationToken cancellationToken)
    {
        var result = await _service.CountByStatusAsync(statusId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("{id:guid}/file")]
    public async Task<IResult> DownloadFile(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetAttachmentsAsync(id, cancellationToken);
        return result.Match(
            data => Results.File(data.File!, data.ContentType ?? "application/octet-stream", data.FileName),
            ApiResults.Problem
        );
    }
}
