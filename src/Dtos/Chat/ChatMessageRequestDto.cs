using System.ComponentModel.DataAnnotations;
using Common.Chat;
using Microsoft.AspNetCore.Http;

namespace Dtos.Chat;

/// <summary>
/// Represents a request to send a message
/// </summary>
public class SendMessageRequestDto
{
    /// <summary>
    /// The ID of the sender
    /// </summary>
    [Required]
    public Guid SenderId { get; set; }

    /// <summary>
    /// The display name of the sender
    /// </summary>
    ///
    [Required]
    public string SenderDisplayName { get; set; } = null!;

    /// <summary>
    /// The ID of the receiver (optional if the message is from user to system)
    /// </summary>
    [Required]
    public Guid ReceiverId { get; set; }

    /// <summary>
    /// The display name of the receiver
    /// </summary>
    public string? ReceiverDisplayName { get; set; } = null!;

    /// <summary>
    /// The message text content
    /// </summary>
    public string? Text { get; set; }
    
    /// <summary>
    /// The type of the message
    /// </summary>
    public ChatMessageType MessageType { get; set; }

    /// <summary>
    /// True if sender is a support agent
    /// </summary>
    public bool SenderIsAgent { get; set; }
    
    /// <summary>
    /// Send byte files but with max size 10 Mg
    /// </summary>
    public IFormFile? File { get; set; }
    
    public string? FileName { get; set; }
}