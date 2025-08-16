using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using Dtos.BasicInformation;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcademyDataController(IAcademyData service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.GetAsync(id, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await service.GetAllAsync(cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpPost]
    public async Task<IResult> Create([FromForm] AcademyDataDto dto, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/AcademyData/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] AcademyDataDto dto, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(id, dto, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.DeleteAsync(id, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpGet("{id:guid}/image")]
    public async Task<IActionResult> GetImage(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.GetImageAsync(id, cancellationToken);
        return result.IsFailure
            ? NotFound()
            : File(result.Value.file, result.Value.contentType ?? "application/octet-stream");
    }

    [HttpGet("{id:guid}/attachment")]
    public async Task<IActionResult> GetAttachment(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.GetAttachmentsAsync(id, cancellationToken);
        return result.IsFailure
            ? NotFound()
            : File(result.Value.file!, result.Value.contentType ?? "application/octet-stream", result.Value.fileName);
    }
}
