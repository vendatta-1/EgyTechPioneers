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
    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = Context.User?.FindFirst(ClaimTypes.Role)?.Value;

        if (string.IsNullOrEmpty(role))
        {
            await Clients.Caller.SendAsync("ErrorMessage", "Role is missing. Connection rejected.");
            Context.Abort();
            return;
        }

        if (!string.IsNullOrEmpty(userId))
        {
            if (role == "SupportAgent")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Support");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            }
        }

        await base.OnConnectedAsync();
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = Context.User?.FindFirst(ClaimTypes.Role)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            if (role == "SupportAgent")
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Support");
            }
            else
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

        await Clients.Caller.SendAsync("ReceiveMessage", "Disconnected.");
    }

    public async Task SendMessageToSupport(SendMessageRequestDto request)
    {
        var result = await chatService.SendMessageAsync(request, CancellationToken.None);
        if (result.IsFailure)
        {
            await Clients.Caller.SendAsync("ErrorMessage", result.Error.Description);
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