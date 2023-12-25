namespace BusinessLogicLayer.DTOs.Relationship
{
    public class RelationshipAddDto
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
