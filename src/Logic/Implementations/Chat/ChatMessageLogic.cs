using Common.Chat;
using Common.Data;
using Common.Results;
using Dtos.Chat;
using Entities.Models.Chat;
using Logic.Interfaces.Chat;
using Logic.Interfaces.Helpers;
using Mapster;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;

namespace Logic.Implementations.Chat;

public class ChatMessageLogic(
    IRepository<ChatMessage> repository,
    IFileService fileService,
    IUnitOfWork unitOfWork
) : IChatMessage
{
    public async Task<Result<MessageResponseDto>> SendMessageAsync(SendMessageRequestDto request, CancellationToken cancellationToken)
    {
        var entity = new ChatMessage
        {
            SenderId = request.SenderId,
            SenderDisplayName = request.SenderDisplayName,
            ReceiverId = request.ReceiverId,
            ReceiverDisplayName = request.ReceiverDisplayName??"System",
            Text = request.Text,
            MessageType = request.MessageType,
            SentAt = DateTime.UtcNow,
            IsRead = false
        };
        
        var insertResult = await repository.InsertAsync(entity, cancellationToken);
        if (insertResult.IsFailure)
            return Result.Failure<MessageResponseDto>(insertResult.Error);

        
        if (request.File is not null && request.File.Length > 0)
        {
            string fileId = await fileService.SaveAsync<ChatMessage>(request.File);
            entity.FilePath = fileId;

            if (request.MessageType == ChatMessageType.Text)
            {
               
                var extension = Path.GetExtension(request.File.FileName).ToLower();
                if (extension == ".mp3" || extension == ".wav" || extension == ".ogg" || extension == ".wma" || extension ==".mp4a")
                    request.MessageType = ChatMessageType.Voice;
                else
                    request.MessageType = ChatMessageType.File;
            }
        }


        

        await unitOfWork.SaveChangesAsync(cancellationToken);
        var dto = entity.Adapt<MessageResponseDto>();

        return Result.Success(dto);
    }

    public async Task<Result<List<MessageResponseDto>>> GetConversationAsync(Guid userIdA, Guid userIdB, CancellationToken cancellationToken)
    {
        var result = await repository.GetFilteredAsync(
            m => (m.SenderId == userIdA && m.ReceiverId == userIdB) ||
                 (m.SenderId == userIdB && m.ReceiverId == userIdA),
            cancellationToken);

        if (result.IsFailure)
            return Result.Failure<List<MessageResponseDto>>(result.Error);

        var list = result.Value.OrderBy(m => m.SentAt).Adapt<List<MessageResponseDto>>();
        return Result.Success(list);
    }

    public Task<Result<(FileStream? file, string? fileName, string? contentType)>> GetFileAsync(string fileId)
    {
        var (stream, fileName) = fileService.Get<ChatMessage>(fileId);
        if (stream is null || fileName is null)
            return Task.FromResult(Result.Failure<(FileStream?, string?, string?)>(Error.NotFound("Chat.FileNotFound", "File not found")));

        var contentType = fileService.GetMimeType(Path.GetExtension(fileName));
        return Task.FromResult(Result.Success((stream, fileName, contentType)));
    }


    public async Task<Result<List<MessageResponseDto>>> GetAllConversationsAsync(CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<List<MessageResponseDto>>())
            : Result.Failure<List<MessageResponseDto>>(result.Error);
    }

    public async Task<Result<List<MessageResponseDto>>> GetUnreadConversationsAsync(CancellationToken cancellationToken)
    {
        var result = await repository.GetFilteredAsync(x => !x.IsRead, cancellationToken);
        return result.IsSuccess
            ? Result.Success(result.Value.Adapt<List<MessageResponseDto>>())
            : Result.Failure<List<MessageResponseDto>>(result.Error);
    }

    public async Task<Result<bool>> MarkAsReadAsync(Guid messageId, CancellationToken cancellationToken)
    {
        var message = await repository.GetByIdAsync(messageId, cancellationToken);
        if (message.IsFailure )
            return Result.Failure<bool>(Error.NotFound("Chat.Message", "Message not found"));

        message.Value.IsRead = true;
        var result = await repository.UpdateAsync(message.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<Result<List<MessageResponseDto>>> GetUserHistoryAsync(Guid userId, CancellationToken cancellationToken)
    {
        var messages = await repository.GetFilteredAsync(x => x.SenderId == userId || x.ReceiverId == userId, cancellationToken);
        return messages.IsSuccess
            ? Result.Success(messages.Value.Adapt<List<MessageResponseDto>>())
            : Result.Failure<List<MessageResponseDto>>(messages.Error);
    }

    public async Task<Result<MessageResponseDto>> ReplyToMessageAsync(Guid messageId, SendMessageRequestDto request, CancellationToken cancellationToken)
    {
        var original = await repository.GetByIdAsync(messageId, cancellationToken);
        if (original.IsFailure )
            return Result.Failure<MessageResponseDto>(Error.NotFound("Message.NotFound", "Message not found"));

        var reply = new ChatMessage
        {
            SenderId = request.SenderId,
            SenderDisplayName = request.SenderDisplayName,
            ReceiverId = request.ReceiverId,
            ReceiverDisplayName = request.ReceiverDisplayName??throw new ArgumentNullException(nameof(ChatMessage.ReceiverDisplayName), "ReceiverDisplayName can not be null"),
            Text = request.Text,
            MessageType = request.MessageType,
            SentAt = DateTime.UtcNow,
            IsRead = true,
            RepliedToMessageId = messageId
        };

        var insertResult = await repository.InsertAsync(reply, cancellationToken);
        if (insertResult.IsFailure)
            return Result.Failure<MessageResponseDto>(insertResult.Error);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(reply.Adapt<MessageResponseDto>());
    }
}