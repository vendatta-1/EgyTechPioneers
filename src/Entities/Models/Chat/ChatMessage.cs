using System.ComponentModel.DataAnnotations;
using Common;
using Common.Chat;

namespace Entities.Models.Chat;


public class ChatMessage:Entity
{ 
    public Guid SenderId { get; set; }
    [MaxLength(75)]
    public string SenderDisplayName { get; set; } = null!;

    public Guid ReceiverId { get; set; }
    [MaxLength(75)]
    
    public string ReceiverDisplayName { get; set; } = null!;

    [MaxLength(1024)]
    public string? Text { get; set; }
    [MaxLength(250)]
    public string? FilePath { get; set; }
    public ChatMessageType MessageType { get; set; }

    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; } = false;

    public Guid? RepliedToMessageId { get; set; }
}