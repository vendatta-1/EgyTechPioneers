using Common.Results;
using Dtos.Chat;

namespace Logic.Interfaces.Chat;

public interface IChatMessage
{
    Task<Result<MessageResponseDto>> SendMessageAsync(SendMessageRequestDto request, CancellationToken cancellationToken);
    Task<Result<List<MessageResponseDto>>> GetConversationAsync(Guid userIdA, Guid userIdB, CancellationToken cancellationToken);
    Task<Result<(FileStream? file, string? fileName, string? contentType)>> GetFileAsync(string fileId);
    Task<Result<List<MessageResponseDto>>> GetAllConversationsAsync(CancellationToken cancellationToken);
    Task<Result<List<MessageResponseDto>>> GetUnreadConversationsAsync(CancellationToken cancellationToken);
    Task<Result<bool>> MarkAsReadAsync(Guid messageId, CancellationToken cancellationToken);
    Task<Result<List<MessageResponseDto>>> GetUserHistoryAsync(Guid userId, CancellationToken cancellationToken);
    Task<Result<MessageResponseDto>> ReplyToMessageAsync(Guid messageId, SendMessageRequestDto request, CancellationToken cancellationToken);
}