namespace BusinessLogicLayer.DTOs.Message
{
    public class MessageAddDto
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public long DialogId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
