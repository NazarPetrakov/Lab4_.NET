namespace BusinessLogicLayer.DTOs.Message
{
    public class MessageGetDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public long DialogId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentDateTime { get; set; }
    }
}
