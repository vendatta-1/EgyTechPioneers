using API.Extensions;
using Common.Constants;
using Common.Services.Interfaces;
using Dtos.Chat;
using Logic.Interfaces.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Chat;

[Route("api/chat")]
[ApiController]
public class ChatController(IChatMessage chatService, ICurrentUserService currentUser) : ControllerBase
{
    [Authorize]
    [HttpPost("send")]
    public async Task<IResult> SendMessage([FromForm] SendMessageRequestDto request, CancellationToken cancellationToken)
    {
        var result = await chatService.SendMessageAsync(request, cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }
 

    [Authorize]
    [HttpPost("reply/{messageId:guid}")]
    public async Task<IResult> ReplyToMessage(Guid messageId, [FromBody] SendMessageRequestDto request, CancellationToken cancellationToken)
    {
        var result = await chatService.ReplyToMessageAsync(messageId, request, cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [Authorize]
    [HttpGet("conversation")]
    public async Task<IResult> GetConversation(CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId;
        if (userId is null)
            return Results.Unauthorized();

        var result = await chatService.GetConversationAsync(Guid.Parse(userId), SystemConstants.SupportSystemId, cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [Authorize]
    [HttpGet("history")]
    public async Task<IResult> GetUserHistory(CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId;
        if (userId is null)
            return Results.Unauthorized();

        var result = await chatService.GetUserHistoryAsync(Guid.Parse(userId), cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [Authorize]
    [HttpGet("file/{fileId}")]
    public async Task<IResult> GetFile(string fileId)
    {
        var result = await chatService.GetFileAsync(fileId);
        return result.Match(
            tuple =>
            {
                var (stream, ext) = tuple;
                if (stream is null)
                    return Results.NotFound();

                return Results.File(stream, "application/octet-stream", $"attachment{ext ?? ".dat"}");
            },
            ApiResults.Problem
        );
    }

    [Authorize(Roles = "SupportAgent")]
    [HttpGet("conversations")]
    public async Task<IResult> GetAllConversations(CancellationToken cancellationToken)
    {
        var result = await chatService.GetAllConversationsAsync(cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [Authorize(Roles = "SupportAgent")]
    [HttpGet("conversations/unread")]
    public async Task<IResult> GetUnreadConversations(CancellationToken cancellationToken)
    {
        var result = await chatService.GetUnreadConversationsAsync(cancellationToken);
        return result.Match(
            data => Results.Ok(data),
            ApiResults.Problem
        );
    }

    [Authorize(Roles = "SupportAgent")]
    [HttpPost("read/{messageId:guid}")]
    public async Task<IResult> MarkAsRead(Guid messageId, CancellationToken cancellationToken)
    {
        var result = await chatService.MarkAsReadAsync(messageId, cancellationToken);
        return result.Match(
            _ => Results.Ok(),
            ApiResults.Problem
        );
    }
   
}
