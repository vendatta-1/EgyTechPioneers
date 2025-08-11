using Common.Chat;

namespace Dtos.Chat;

/// <summary>
/// Represents a message in the conversation
/// </summary>
public class MessageResponseDto
{
    /// <summary>
    /// The ID of the message
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The ID of the sender
    /// </summary>
    public Guid SenderId { get; set; }

    /// <summary>
    /// The display name of the sender
    /// </summary>
    public string SenderDisplayName { get; set; } = null!;

    /// <summary>
    /// The ID of the receiver
    /// </summary>
    public Guid ReceiverId { get; set; }

    /// <summary>
    /// The display name of the receiver
    /// </summary>
    public string ReceiverDisplayName { get; set; } = null!;

    /// <summary>
    /// The content of the message
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// The file ID path if a file was attached
    /// </summary>
    public string? FilePath { get; set; }

    /// <summary>
    /// The type of message (text, audio, file, etc.)
    /// </summary>
    public ChatMessageType MessageType { get; set; }

    /// <summary>
    /// The timestamp the message was sent
    /// </summary>
    public DateTime SentAt { get; set; }

    /// <summary>
    /// Whether the message was read
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// The ID of the support agent who replied (optional)
    /// </summary>
    public Guid? RespondedByAgentId { get; set; }

    /// <summary>
    /// The name of the agent who responded
    /// </summary>
    public string? RespondedByDisplayName { get; set; }
}