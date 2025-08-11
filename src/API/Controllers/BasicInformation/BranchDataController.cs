using Dtos.BasicInformation;
using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BranchDataController : ControllerBase
{
    private readonly IBranchData _service;

    public BranchDataController(IBranchData service)
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
    public async Task<IResult> Create([FromForm] BranchDataDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/BranchData/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromForm] BranchDataDto dto, CancellationToken cancellationToken)
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

    [HttpGet("by-academy/{academyId:guid}")]
    public async Task<IResult> GetByAcademyId(Guid academyId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByAcademyIdAsync(academyId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("by-governorate/{governorateId:guid}")]
    public async Task<IResult> GetByGovernorateId(Guid governorateId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByGovernorateIdAsync(governorateId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }

    [HttpGet("by-city/{cityId:guid}")]
    public async Task<IResult> GetByCityId(Guid cityId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByCityIdAsync(cityId, cancellationToken);
        return result.Match(Results.Ok, ApiResults.Problem);
    }
}
