using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using Dtos.BasicInformation;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcademyClaseMasterController : ControllerBase
{
    private readonly IAcademyClaseMaster _service;

    public AcademyClaseMasterController(IAcademyClaseMaster service)
    {
        _service = service;
    }

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
    public async Task<IResult> Create([FromForm] AcademyClaseMasterDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/AcademyClaseMaster/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] AcademyClaseMasterDto dto, CancellationToken cancellationToken)
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
}