using Dtos.Chat;
using Logic.Interfaces.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Common.Constants;

namespace API.Hubs;
 
[AllowAnonymous]
public class ChatHub(IChatMessage chatService) : Hub
{
    public override Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
        return base.OnConnectedAsync();
    }
 

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessageToSupport(SendMessageRequestDto request)
    {
        var result = await chatService.SendMessageAsync(request, CancellationToken.None);
        if (result.IsFailure)
        {
            await Clients.Caller.SendAsync("ErrorMessage",result.Error.Description);
        }
        
        await Clients.Group("Support").SendAsync("ReceiveMessage", result.Value);
    }

    public async Task SendMessageToUser(SendMessageRequestDto request)
    {
        if (request.ReceiverId == SystemConstants.SupportSystemId)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", "The receiver can not be the support ");
        }
        var result = await chatService.SendMessageAsync(request, CancellationToken.None);
        
        if (result.IsFailure) return;

        await Clients.Group(request.ReceiverId.ToString()).SendAsync("ReceiveMessage", result.Value);
    }

    [Authorize(Roles = "SupportAgent")]
    public async Task ReplyToMessage(Guid messageId, SendMessageRequestDto request)
    {
        var result = await chatService.ReplyToMessageAsync(messageId, request, default);
        if (result.IsFailure) return;

        await Clients.Group(request.ReceiverId.ToString()).SendAsync("ReceiveMessage", result.Value);
    }

    public Task MarkAsRead(Guid messageId)
    {
        return chatService.MarkAsReadAsync(messageId, default);
    }
}

 