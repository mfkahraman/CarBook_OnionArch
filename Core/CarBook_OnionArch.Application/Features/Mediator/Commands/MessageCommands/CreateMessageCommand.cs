using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.MessageCommands
{
    public class CreateMessageCommand : IRequest<bool>
    {
        public required string Sender { get; set; }
        public int SenderId { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
