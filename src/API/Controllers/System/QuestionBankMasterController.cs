using API.Extensions;
using Dtos.System;
using Logic.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.System;

[ApiController]
[Route("api/[controller]")]
public class QuestionBankMasterController(IQuestionBankMaster service) : ControllerBase
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

    [HttpGet("by-program/{programId:guid}")]
    public async Task<IResult> GetByProgramId(Guid programId, CancellationToken ct)
    {
        var result = await service.GetByProgramIdAsync(programId, ct);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] QuestionBankMasterDto dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto, ct);
        return result.Match(
            data => Results.Created($"/api/QuestionBankMaster/{data.Id}", data),
            ApiResults.Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IResult> Update(Guid id, [FromBody] QuestionBankMasterDto dto, CancellationToken ct)
    {
        dto.Id = id;
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
