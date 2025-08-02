using API.Extensions;
using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Mvc;
using Dtos.BasicInformation;
using Microsoft.AspNetCore.Http;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
public class AcademyClaseDetailController(IAcademyClaseDetail service) : ControllerBase
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
    public async Task<IResult> Create([FromForm] AcademyClaseDetailDto dto, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/AcademyClaseDetail/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] AcademyClaseDetailDto dto, CancellationToken cancellationToken)
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
    public async Task<IResult> GetImage(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.GetImageByIdAsync(id);
        if (!result.IsSuccess)
            return ApiResults.Problem(result);

        if (result.Value.Stream == null || result.Value.ContentType == null)
            return Results.NotFound();

        return Results.File(result.Value.Stream, result.Value.ContentType);
    }
}
