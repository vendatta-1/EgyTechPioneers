using Dtos.BasicInformation;
using Logic.Interfaces.BasicInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;

namespace API.Controllers.BasicInformation;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CountryCodeController(ICountryCode service) : ControllerBase
{
    private readonly ICountryCode _service = service;

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
    public async Task<IResult> Create([FromBody] CountryCodeDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return result.Match(
            data => Results.Created($"/api/CountryCode/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromBody] CountryCodeDto dto, CancellationToken cancellationToken)
    {
        dto.Id = id;
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