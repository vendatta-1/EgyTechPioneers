using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using Dtos.BasicInformation;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcademyClaseTypeController(IAcademyClaseType service) : ControllerBase
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
    public async Task<IResult> Create([FromForm] AcademyClaseTypeDto dto, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/AcademyClaseType/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] AcademyClaseTypeDto dto, CancellationToken cancellationToken)
    {
        dto.Id = id;
        var result = await service.UpdateAsync(id, dto, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await service.DeleteAsync(id, cancellationToken);
        return result.Match(Results.NoContent, ApiResults.Problem);
    }
}